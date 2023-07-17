using Core.DTOs.Genre;

namespace Core.Interfaces
{
    public interface IGenreServices
    {
        Task CreateAsync(GenreCreateDTO genreData);
        Task UpdateAsync(GenreUpdateDTO genreData);
        Task RecoveryAsync(int id);
        Task DeleteAsync(int id);
        Task DeleteWithoutRecoveryAsync(int id);

        Task<GenreItemDTO> GetByIdAsync(int id);
        Task<IEnumerable<GenreItemDTO>> GetAllAsync();
        Task<IEnumerable<GenreItemDTO>> GetAllActiveAsync();
        Task<IEnumerable<GenreItemDTO>> GetAllDeletedAsync();
    }
}