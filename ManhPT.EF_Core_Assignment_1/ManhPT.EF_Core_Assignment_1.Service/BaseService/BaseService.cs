using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Repository.BaseRepository;

namespace ManhPT.EF_Core_Assignment_1.Service
{
    public abstract class BaseService<TEntity, TEntityDto, TEntityCreateDto>(IBaseRepository<TEntity> repository, IMapper mapper) : IBaseService<TEntityDto, TEntityCreateDto> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public void DeleteAsync(Guid Id)
        {
            _repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<TEntityDto>>(entities);
            return dtos;
        }

        public async Task<TEntityDto> GetByIdAsync(Guid Id)
        {
            var entity = await _repository.GetByIdAsync(Id);
            var dto = _mapper.Map<TEntityDto>(entity);
            return dto;

        }

        public void InsertAsync(TEntityCreateDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            _repository.InsertAsync(entity);
        }

        public void UpdateAsync(Guid id, TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            _repository.UpdateAsync(entity);
        }
    }
}
