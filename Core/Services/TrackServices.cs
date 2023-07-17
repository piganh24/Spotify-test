using System.Net;
using AutoMapper;
using Core.DTOs.Track;
using Core.Entities;
using Core.Entities.Identity;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources.ErrorMassages;
using Microsoft.AspNetCore.Identity;

namespace Core.Services
{
    public class TrackServices : ITrackServices
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Track> _repository;
        private readonly UserManager<UserEntity> _userManager;

        public TrackServices(IRepository<Track> repository, IMapper mapper, UserManager<UserEntity> userManager)
        {
            _mapper = mapper;
            _repository = repository;
            _userManager = userManager;
        }

        public async Task CreateAsync(string username, TrackCreateDTO trackData)
        {
            var user = await _userManager.FindByEmailAsync(username) ?? throw new HttpExceptionWorker(username + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);

            var nameSavedImage = await ImageWorker.SaveImageAsync(trackData.Image);
            var infoSavedTrack = await TrackWorker.SaveTrackAsync(trackData.Track);

            trackData.UserId = user.Id;
            trackData.Image = nameSavedImage;
            trackData.Path = infoSavedTrack.FileName;
            trackData.Duration = infoSavedTrack.Duration;
            trackData.DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            await _repository.AddAsync(_mapper.Map<Track>(trackData));
            await _repository.SaveAsync();
        }

        public async Task UpdateTrackDataAsync(TrackUpdateDTO trackData)
        {
            var track = await _repository.GetByIdAsync(trackData.Id) ?? throw new HttpExceptionWorker(ErrorMassages.IdValueError, HttpStatusCode.NotFound);

            await ImageWorker.RemoveImageAsync(track.Image); // deleting old photo
            trackData.Image = await ImageWorker.SaveImageAsync(trackData.Image); // saving base64 from DTO to folder and saving path to saved photo
            track.Image = trackData.Image; // update the photo path in the entity
            track.DateUpdated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            _mapper.Map(trackData, track);
            await _repository.UpdateAsync(track);
            await _repository.SaveAsync();
        }

        public async Task RecoveryAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var track = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            track.IsDeleted = false;
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var track = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            track.IsDeleted = true;
            await _repository.SaveAsync();
        }

        public async Task DeleteWithoutRecoveryAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var track = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);

            await ImageWorker.RemoveImageAsync(track.Image);
            await TrackWorker.RemoveTrackAsync(track.Path);
            _repository.Delete(track);

            await _repository.SaveAsync();
        }

        public async Task<TrackItemDTO> GetByIdAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);

            var track = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            if (track.IsDeleted == false)
                return _mapper.Map<TrackItemDTO>(track);

            return null;
        }

        public async Task<IEnumerable<TrackItemDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TrackItemDTO>>(await _repository.GetAllAsync());
        }

        public async Task<IEnumerable<TrackItemDTO>> GetAllActiveAsync()
        {
            var allTracks = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TrackItemDTO>>(allTracks.Where(track => track.IsDeleted == false));
        }

        public async Task<IEnumerable<TrackItemDTO>> GetAllDeletedAsync()
        {
            var allTracks = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TrackItemDTO>>(allTracks.Where(track => track.IsDeleted == true));
        }

        public async Task<IEnumerable<TrackItemDTO>> GetAllByGenreIdAsync(int genreId)
        {
            var tracks = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TrackItemDTO>>(tracks.Where(track => track.GenreId == genreId)
                                                                .Where(track => track.IsDeleted == false));
        }

        public async Task<IEnumerable<TrackItemDTO>> GetAllByPerformerIdAsync(int performerId)
        {
            var tracks = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TrackItemDTO>>(tracks.Where(track => track.UserId == performerId)
                                                                .Where(track => track.IsDeleted == false));
        }

        public async Task<IEnumerable<TrackItemDTO>> GetAllMyTracksAsync(string username)
        {
            var user = await _userManager.FindByEmailAsync(username) ?? throw new HttpExceptionWorker(username + ErrorMassages.ItemNotFount, HttpStatusCode.NotFound);
            var tracks = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<TrackItemDTO>>(tracks.Where(track => track.UserId == user.Id)
                                                                .Where(track => track.IsDeleted == false));
        }

        public async Task<IEnumerable<TrackItemDTO>> GetAllPublicAsync()
        {
            var tracks = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TrackItemDTO>>(tracks.Where(track => track.IsPublic == true)
                                                                .Where(track => track.IsDeleted == false));
        }

        public async Task<IEnumerable<TrackItemDTO>> GetAllExplicitAsync()
        {
            var tracks = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TrackItemDTO>>(tracks.Where(track => track.IsExplicit == true)
                                                                .Where(track => track.IsDeleted == false));
        }

        public bool IsExistTrack(int id)
        {
            var result = _repository.GetByIdAsync(id).Result;
            return result != null;
        }
    }
}