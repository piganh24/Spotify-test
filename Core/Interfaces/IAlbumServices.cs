using Core.DTOs.Album;

namespace Core.Interfaces
{
    public interface IAlbumServices
    {
        Task CreateAsync(string username, AlbumCreateDTO albumData);
        Task UpdateAsync(AlbumUpdateDTO albumData);
        Task RecoveryAsync(int id);
        Task DeleteAsync(int id);
        Task DeleteWithoutRecoveryAsync(int id);

        Task<AlbumItemDTO> GetByIdAsync(int id);
        Task<IEnumerable<AlbumItemDTO>> GetAllAsync();
        Task<IEnumerable<AlbumItemDTO>> GetAllPublicAsync();
        Task<IEnumerable<AlbumItemDTO>> GetAllByGenreIdAsync(int genreId);
        Task<IEnumerable<AlbumItemDTO>> GetAllByPerformerIdAsync(int performerId);
        Task<IEnumerable<AlbumItemDTO>> GetAllMyAlbumsAsync(string username);
    }
}