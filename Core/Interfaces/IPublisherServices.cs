using Core.DTOs.Publisher;

namespace Core.Interfaces
{
    public interface IPublisherServices
    {
        Task CreateAsync(PublisherCreateDTO publisherData);
        Task UpdateAsync(PublisherUpdateDTO publisherData);
        Task RecoveryAsync(int id);
        Task DeleteAsync(int id);
        Task DeleteWithoutRecoveryAsync(int id);

        Task<PublisherItemDTO> GetByIdAsync(int id);
        Task<IEnumerable<PublisherItemDTO>> GetAllAsync();
    }
}