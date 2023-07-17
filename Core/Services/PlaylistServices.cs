using System.Net;
using AutoMapper;
using Core.DTOs.Playlist;
using Core.Entities;
using Core.Entities.Identity;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources.ErrorMassages;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services
{
    public class PlaylistServices : IPlaylistServices
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Playlist> _repository;
        private readonly UserManager<UserEntity> _userManager;

        public PlaylistServices(IRepository<Playlist> repository, IMapper mapper, UserManager<UserEntity> userManager)
        {
            _mapper = mapper;
            _repository = repository;
            _userManager = userManager;
        }

        public async Task CreateAsync(string username, PlaylistCreateDTO playlistData)
        {
            var user = await _userManager.FindByEmailAsync(username) ?? throw new HttpExceptionWorker(username + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);
            playlistData.UserId = user.Id;
            playlistData.Image = await ImageWorker.SaveImageAsync(playlistData.Image);
            playlistData.DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            await _repository.AddAsync(_mapper.Map<Playlist>(playlistData));
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(PlaylistUpdateDTO playlistData)
        {
            try
            {
                Playlist playlist = await _repository.GetByIdAsync(playlistData.Id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);

                if (!playlistData.Image.IsNullOrEmpty())
                {
                    await ImageWorker.RemoveImageAsync(playlist.Image); // deleting old photo
                    playlistData.Image = await ImageWorker.SaveImageAsync(playlistData.Image); // saving base64 from DTO to folder and saving path to saved photo
                    playlist.Image = playlistData.Image; // update the photo path in the entity
                }

                playlist.DateUpdated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

                _mapper.Map(playlistData, playlist); // update other properties of the entity
                await _repository.UpdateAsync(playlist);
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
            var playlist = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            playlist.IsDeleted = false;
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var playlist = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            playlist.IsDeleted = true;
            await _repository.SaveAsync();
        }

        public async Task DeleteWithoutRecoveryAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            _repository.Delete(await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound));
            await _repository.SaveAsync();
        }

        public async Task<PlaylistItemDTO> GetByIdAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var playlist = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            if (playlist.IsDeleted == false)
                return _mapper.Map<PlaylistItemDTO>(playlist);

            return null;
        }

        public async Task<IEnumerable<PlaylistItemDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PlaylistItemDTO>>(await _repository.GetAllAsync());
        }

        public async Task<IEnumerable<PlaylistItemDTO>> GetAllByGenreIdAsync(int genreId)
        {
            var playlists = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlaylistItemDTO>>(playlists.Where(playlists => playlists.GenreId == genreId)
                                                                      .Where(track => track.IsDeleted == false));
        }

        public async Task<IEnumerable<PlaylistItemDTO>> GetAllMyPlaylistsAsync(string username)
        {
            var user = await _userManager.FindByEmailAsync(username) ?? throw new HttpExceptionWorker(username + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);
            var playlists = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<PlaylistItemDTO>>(playlists.Where(playlists => playlists.UserId == user.Id)
                                                                      .Where(track => track.IsDeleted == false));
        }
        public async Task<IEnumerable<PlaylistItemDTO>> GetAllPublicAsync()
        {
            var playlists = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlaylistItemDTO>>(playlists.Where(playlists => playlists.IsPublic == true)
                                                                      .Where(playlist => playlist.IsDeleted == false));
        }

        public bool IsExistPlaylist(int id)
        {
            var result = _repository.GetByIdAsync(id);
            return result != null;
        }
    }
}