using System.Net;
using AutoMapper;
using Core.DTOs.Publisher;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services
{
    public class PublisherServices : IPublisherServices
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Publisher> _repository;

        public PublisherServices(IRepository<Publisher> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(PublisherCreateDTO publisherData)
        {
            publisherData.Image = await ImageWorker.SaveImageAsync(publisherData.Image);
            publisherData.DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            await _repository.AddAsync(_mapper.Map<Publisher>(publisherData));
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(PublisherUpdateDTO publisherData)
        {
            try
            {
                Publisher publisher = await _repository.GetByIdAsync(publisherData.Id) ?? throw new HttpExceptionWorker("Not found!", HttpStatusCode.NotFound);

                if (!publisherData.Image.IsNullOrEmpty())
                {
                    await ImageWorker.RemoveImageAsync(publisher.Image); // deleting old photo
                    publisherData.Image = await ImageWorker.SaveImageAsync(publisherData.Image); // saving base64 from DTO to folder and saving path to saved photo
                    publisher.Image = publisherData.Image; // update the photo path in the entity
                }
                publisher.DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

                _mapper.Map(publisherData, publisher); // update other properties of the entity
                await _repository.UpdateAsync(publisher);
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
            var publisher = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            publisher.IsDeleted = false;
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var publisher = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            publisher.IsDeleted = true;
            await _repository.SaveAsync();
        }

        public async Task DeleteWithoutRecoveryAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            _repository.Delete(await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound));
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<PublisherItemDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PublisherItemDTO>>(await _repository.GetAllAsync());
        }

        public async Task<PublisherItemDTO> GetByIdAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var publisher = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            if (publisher.IsDeleted == false)
                return _mapper.Map<PublisherItemDTO>(publisher);

            return null;
        }

        public bool IsExistPublisher(int id)
        {
            var result = _repository.GetByIdAsync(id).Result;
            return result != null;
        }
    }
}