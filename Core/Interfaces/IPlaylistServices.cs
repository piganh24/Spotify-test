using Core.DTOs.Playlist;

namespace Core.Interfaces
{
    public interface IPlaylistServices
    {
        Task CreateAsync(string username, PlaylistCreateDTO playlistData);
        Task UpdateAsync(PlaylistUpdateDTO playlistData);
        Task RecoveryAsync(int id);
        Task DeleteAsync(int id);
        Task DeleteWithoutRecoveryAsync(int id);

        Task<PlaylistItemDTO> GetByIdAsync(int id);
        Task<IEnumerable<PlaylistItemDTO>> GetAllAsync();
        Task<IEnumerable<PlaylistItemDTO>> GetAllPublicAsync();
        Task<IEnumerable<PlaylistItemDTO>> GetAllByGenreIdAsync(int genreId);
        Task<IEnumerable<PlaylistItemDTO>> GetAllMyPlaylistsAsync(string username);
    }
}