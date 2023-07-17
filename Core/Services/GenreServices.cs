using System.Net;
using AutoMapper;
using Core.DTOs.Genre;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services
{
    public class GenreServices : IGenreServices
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Genre> _repository;

        public GenreServices(IRepository<Genre> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(GenreCreateDTO genreData)
        {
            genreData.Image = await ImageWorker.SaveImageAsync(genreData.Image);
            genreData.DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            await _repository.AddAsync(_mapper.Map<Genre>(genreData));
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(GenreUpdateDTO genreData)
        {
            try
            {
                Genre genre = await _repository.GetByIdAsync(genreData.Id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);

                if (!genreData.Image.IsNullOrEmpty())
                {
                    await ImageWorker.RemoveImageAsync(genre.Image); // deleting old photo
                    genreData.Image = await ImageWorker.SaveImageAsync(genreData.Image); // saving base64 from DTO to folder and saving path to saved photo
                    genre.Image = genreData.Image; // update the photo path in the entity
                }
                genreData.DateUpdated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                _mapper.Map(genreData, genre); // update other properties of the entity
                await _repository.UpdateAsync(genre);
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
            var genre = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            genre.IsDeleted = false;
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var genre = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            genre.IsDeleted = true;
            await _repository.SaveAsync();
        }

        public async Task DeleteWithoutRecoveryAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            _repository.Delete(await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound));
            await _repository.SaveAsync();
        }

        public async Task<GenreItemDTO> GetByIdAsync(int id)
        {
            await DataWorker.IsValidIdAsync(id);
            var genre = await _repository.GetByIdAsync(id) ?? throw new HttpExceptionWorker(HttpStatusCode.NotFound);
            if (genre.IsDeleted == false)
                return _mapper.Map<GenreItemDTO>(genre);

            return null;
        }

        public async Task<IEnumerable<GenreItemDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GenreItemDTO>>(await _repository.GetAllAsync());
        }

        public async Task<IEnumerable<GenreItemDTO>> GetAllActiveAsync()
        {
            var all = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreItemDTO>>(all.Where(genre => genre.IsDeleted == false));
        }

        public async Task<IEnumerable<GenreItemDTO>> GetAllDeletedAsync()
        {
            var all = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreItemDTO>>(all.Where(genre => genre.IsDeleted == true));
        }

        public bool IsExistGenre(int id)
        {
            var result = _repository.GetByIdAsync(id).Result;
            return result != null;
        }
    }
}