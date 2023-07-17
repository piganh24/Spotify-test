using System.Net;
using AutoMapper;
using Core.DTOs.Album;
using Core.Entities;
using Core.Entities.Identity;
using Core.Resources.ErrorMassages;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services
{
    public class AlbumServices : IAlbumServices
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Album> _repository;
        private readonly UserManager<UserEntity> _userManager;

        public AlbumServices(IRepository<Album> repository, IMapper mapper, UserManager<UserEntity> userManager)
        {
            _mapper = mapper;
            _repository = repository;
            _userManager = userManager;
        }

        public async Task CreateAsync(string username, AlbumCreateDTO albumData)
        {
            var user = await _userManager.FindByEmailAsync(username) ?? throw new HttpExceptionWorker(username + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);
            albumData.UserId = user?.Id;
            albumData.Image = await ImageWorker.SaveImageAsync(albumData.Image);
            albumData.DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            await _repository.AddAsync(_mapper.Map<Album>(albumData));
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(AlbumUpdateDTO albumData)
        {
            try
            {
                Album album = await _repository.GetByIdAsync(albumData.Id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);

                if (!albumData.Image.IsNullOrEmpty())
                {
                    await ImageWorker.RemoveImageAsync(album.Image); // deleting old photo
                    albumData.Image = await ImageWorker.SaveImageAsync(albumData.Image); // saving base64 from DTO to folder and saving path to saved photo
                    album.Image = albumData.Image; // update the photo path in the entity
                }

                albumData.DateUpdated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

                _mapper.Map(albumData, album);
                await _repository.UpdateAsync(album);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new HttpExceptionWorker(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public async Task RecoveryAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var album = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);

            album.IsDeleted = false;
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var album = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            album.IsDeleted = true;
            await _repository.SaveAsync();
        }

        public async Task DeleteWithoutRecoveryAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            _repository.Delete(await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound));
            await _repository.SaveAsync();
        }

        public async Task<AlbumItemDTO> GetByIdAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var album = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            if (album.IsDeleted == false)
                return _mapper.Map<AlbumItemDTO>(album);

            return null;
        }

        public async Task<IEnumerable<AlbumItemDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AlbumItemDTO>>(await _repository.GetAllAsync());
        }

        public async Task<IEnumerable<AlbumItemDTO>> GetAllByGenreIdAsync(int genreId)
        {
            await DataWorker.IsValidIdAsync(genreId);
            var albums = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AlbumItemDTO>>(albums.Where(album => album.GenreId == genreId)
                                                                .Where(album => album.IsDeleted == false));
        }

        public async Task<IEnumerable<AlbumItemDTO>> GetAllByPerformerIdAsync(int performerId)
        {
            await DataWorker.IsValidIdAsync(performerId);
            var albums = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AlbumItemDTO>>(albums.Where(albom => albom.UserId == performerId)
                                                                .Where(album => album.IsDeleted == false));
        }

        public async Task<IEnumerable<AlbumItemDTO>> GetAllMyAlbumsAsync(string username)
        {
            var user = await _userManager.FindByEmailAsync(username) ?? throw new HttpExceptionWorker(username + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);
            var albums = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<AlbumItemDTO>>(albums.Where(albom => albom.UserId == user.Id)
                                                                .Where(album => album.IsDeleted == false));
        }

        public async Task<IEnumerable<AlbumItemDTO>> GetAllPublicAsync()
        {
            var albums = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AlbumItemDTO>>(albums.Where(albom => albom.IsPublic == true)
                                                                .Where(album => album.IsDeleted == false));
        }

        public bool IsExistAlbum(int id)
        {
            var result = _repository.GetByIdAsync(id).Result;
            return result != null;
        }
    }
}