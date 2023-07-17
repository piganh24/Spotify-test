using System.Net;
using Core.Helpers;
using Core.DTOs;
using Core.Interfaces;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Core.Resources.ErrorMassages;
using Core.Resources.Constants;
using AutoMapper;
using Core.DTOs.Account;
using Core.DTOs.Identity;

namespace Core.Services
{
    public class AccountUserServices : IAccountUserServices
    {
        private readonly IMapper _mapper;
        private readonly IJwtTokenServices _jwtTokenService;
        private readonly IRepository<UserEntity> _repository;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        private readonly ITrackServices _trackServices;
        private readonly IAlbumServices _albumServices;
        private readonly IPlaylistServices _playlistServices;

        public AccountUserServices(IRepository<UserEntity> repository, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, IJwtTokenServices jwtTokenServices, IMapper mapper,
                                IAlbumServices albumServices, ITrackServices trackServices, IPlaylistServices playlistServices)
        {
            _mapper = mapper;
            _jwtTokenService = jwtTokenServices;
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;

            _trackServices = trackServices;
            _albumServices = albumServices;
            _playlistServices = playlistServices;
        }

        public async Task SignUpAsync(SignUpItemDTO data)
        {
            string uniqueVerifiacationCode = Guid.NewGuid().ToString();
            UserEntity user = new UserEntity()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                UserName = data.UserName,
                AboutMe = data.AboutMe,
                Image = await ImageWorker.SaveImageAsync(data.Image),
                Email = data.Email,
                IsDeleted = false,
                IsBloked = false,
                IsVerified = false,
                UniqueVerifiacationCode = uniqueVerifiacationCode,
                DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
            };

            var result = await _userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.User);
                await EmailWorker.SendWelcomeEmail(data.Email);
                await EmailWorker.SendVerifyEmail(data.Email, uniqueVerifiacationCode);
            }

            else if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpExceptionWorker(errors, HttpStatusCode.BadRequest);
            }
        }

        public async Task<SignInResponseDTO> SignInAsync(string email, string password)
        {
            UserEntity user = await _userManager.FindByEmailAsync(email) ?? throw new HttpExceptionWorker(email + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
                throw new HttpExceptionWorker(HttpStatusCode.BadRequest);

            await _signInManager.SignInAsync(user, true);

            SignInResponseDTO response = new SignInResponseDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                AboutMe = user.AboutMe,
                Email = email,
                Image = user.Image,
                IsDeleted = user.IsDeleted,
                IsBlocked = user.IsBloked,
                IsVerified = user.IsVerified,
                DateCreated = user.DateCreated,
                DateUpdated = user.DateUpdated,
                Token = await _jwtTokenService.CreateTokenAsync(user)
            };

            return _mapper.Map<SignInResponseDTO>(response);
        }

        public async Task SignOutAsync() => await _signInManager.SignOutAsync();

        public async Task UpdateUserAsync(UserUpdateDTO userDTO)
        {
            await DataWorker.IsValidIdAsync(userDTO.Id);
            UserEntity user = await _userManager.FindByIdAsync(Convert.ToString(userDTO.Id)) ?? throw new HttpExceptionWorker(userDTO.Email + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);

            user.FirstName = userDTO.FirstName ?? string.Empty;
            user.LastName = userDTO.LastName ?? string.Empty;
            user.UserName = userDTO.Email ?? string.Empty;
            user.Email = userDTO.Email;
            user.IsDeleted = userDTO.IsDeleted;
            user.NormalizedUserName = userDTO.Email ?? string.Empty.ToUpper();

            if (!userDTO.Image.IsNullOrEmpty()) // work if user updated photo
            {
                await ImageWorker.RemoveImageAsync(user.Image); // deleting old photo
                user.Image = await ImageWorker.SaveImageAsync(userDTO.Image); // saving base64 from DTO to folder, and saving path to saved photo     
            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpExceptionWorker(errors, HttpStatusCode.BadRequest);
            }
        }

        public async Task<bool> ConfirmUserEmailAsync(string userEmail, string userUniqueVerificationCode)
        {
            UserEntity user = await _userManager.FindByEmailAsync(userEmail) ?? throw new HttpExceptionWorker(userEmail + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);
            if (user.UniqueVerifiacationCode == userUniqueVerificationCode && user.EmailConfirmed != true)
            {
                user.EmailConfirmed = true;
                await _repository.SaveAsync();
                return true;
            }
            return false;
        }

        public async Task ChangePasswordAsync(string userEmail,string newPassword,string confirmPassword)
        {
            UserEntity user = await _userManager.FindByEmailAsync(userEmail) ?? throw new HttpExceptionWorker(userEmail + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);
            if (newPassword == confirmPassword)
            {
                user.PasswordHash = newPassword;
                await _repository.SaveAsync();
            }
            else
            {
                throw new HttpExceptionWorker(HttpStatusCode.BadRequest);
            }
        }

        public async Task DeleteUserAsync(string userEmail, string userPassword)
        {
            UserEntity user = await _userManager.FindByEmailAsync(userEmail) ?? throw new HttpExceptionWorker(userEmail + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userPassword)) throw new HttpExceptionWorker(ErrorMassages.BadCredentialsError, HttpStatusCode.BadRequest);

            var allTracks = await _trackServices.GetAllAsync();
            foreach (var track in allTracks.Where(track => track.UserId == user.Id))
                await _trackServices.DeleteAsync(track.Id);

            var allAlbum = await _albumServices.GetAllAsync();
            foreach (var album in allAlbum.Where(album => album.UserId == user.Id))
                await _albumServices.DeleteAsync(album.Id);

            var allPlaylists = await _playlistServices.GetAllAsync();
            foreach (var playlist in allPlaylists.Where(playlist => playlist.UserId == user.Id))
                await _trackServices.DeleteAsync(playlist.Id);

            user.IsDeleted = true;

            await _repository.SaveAsync();
        }

        public async Task DeleteUserWithoutRecoveryAsync(string userEmail, string userPassword)
        {
            UserEntity user = await _userManager.FindByEmailAsync(userEmail) ?? throw new HttpExceptionWorker(userEmail + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userPassword)) throw new HttpExceptionWorker(HttpStatusCode.BadRequest); // user must write his password in order to delete his account

            // Deleting all data which user uploaded, without the possibility of recovery
            // Deleting all tracks, which user uploaded
            var allTracks = await _trackServices.GetAllAsync();
            foreach (var track in allTracks.Where(track => track.UserId == user.Id))
                await _trackServices.DeleteWithoutRecoveryAsync(track.Id);

            // Deleting all album, which user uploaded
            var allAlbum = await _albumServices.GetAllAsync();
            foreach (var album in allAlbum.Where(album => album.UserId == user.Id))
                await _albumServices.DeleteWithoutRecoveryAsync(album.Id);

            // Deleting all playlists, which users created (uploaded)
            var allPlaylists = await _playlistServices.GetAllAsync();
            foreach (var playlist in allPlaylists.Where(playlist => playlist.UserId == user.Id))
                await _trackServices.DeleteWithoutRecoveryAsync(playlist.Id);

            // Deleting user's image
            await ImageWorker.RemoveImageAsync(user.Image);

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpExceptionWorker(errors, HttpStatusCode.BadRequest);
            }
        }

        public async Task RecoveryUser(string userEmail, string userPassword)
        {
            UserEntity user = await _userManager.FindByEmailAsync(userEmail) ?? throw new HttpExceptionWorker(userEmail + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userPassword)) throw new HttpExceptionWorker(HttpStatusCode.BadRequest);

            var allTracks = await _trackServices.GetAllAsync();
            foreach (var track in allTracks.Where(track => track.UserId == user.Id))
                await _trackServices.RecoveryAsync(track.Id);

            var allAlbum = await _albumServices.GetAllAsync();
            foreach (var album in allAlbum.Where(album => album.UserId == user.Id))
                await _albumServices.RecoveryAsync(album.Id);

            var allPlaylists = await _playlistServices.GetAllAsync();
            foreach (var playlist in allPlaylists.Where(playlist => playlist.UserId == user.Id))
                await _trackServices.RecoveryAsync(playlist.Id);

            user.IsDeleted = false;
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return _mapper.Map<IEnumerable<UserEntity>>(await _repository.GetAllAsync());
        }

        public async Task<IEnumerable<UserEntity>> GetAllDeletedUsersAsync()
        {
            var allUsers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserEntity>>(allUsers.Where(user => user.IsDeleted == true));
        }

        public async Task<IEnumerable<UserEntity>> GetAllActiveUsersAsync()
        {
            var allUsers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserEntity>>(allUsers.Where(user => user.IsDeleted == false));
        }

        public async Task<UserEntity> GetUserByEmailAsync(string userEmail)
        {
            return _mapper.Map<UserEntity>(await _userManager.FindByEmailAsync(userEmail) ?? throw new HttpExceptionWorker(userEmail + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound));
        }

        public async Task<UserEntity> GetUserByUsernameAsync(string userName)
        {
            return _mapper.Map<UserEntity>(await _userManager.FindByNameAsync(userName) ?? throw new HttpExceptionWorker(userName + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound));
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            await DataWorker.IsValidIdAsync(userId);

            return _mapper.Map<UserEntity>(await _repository.GetByIdAsync(userId) ?? throw new HttpExceptionWorker(userId + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound));
        }
    }
}