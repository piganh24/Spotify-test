using Core.DTOs.Track;

namespace Core.Interfaces
{
    public interface ITrackServices
    {
        Task CreateAsync(string username, TrackCreateDTO trackData);
        Task UpdateTrackDataAsync(TrackUpdateDTO trackData);
        Task RecoveryAsync(int id);
        Task DeleteAsync(int id);
        Task DeleteWithoutRecoveryAsync(int id);

        Task<TrackItemDTO> GetByIdAsync(int id);
        Task<IEnumerable<TrackItemDTO>> GetAllAsync();
        Task<IEnumerable<TrackItemDTO>> GetAllActiveAsync();
        Task<IEnumerable<TrackItemDTO>> GetAllDeletedAsync();
        Task<IEnumerable<TrackItemDTO>> GetAllPublicAsync();
        Task<IEnumerable<TrackItemDTO>> GetAllExplicitAsync();
        Task<IEnumerable<TrackItemDTO>> GetAllByGenreIdAsync(int genreId);
        Task<IEnumerable<TrackItemDTO>> GetAllByPerformerIdAsync(int performerId);
        Task<IEnumerable<TrackItemDTO>> GetAllMyTracksAsync(string username);
    }
}