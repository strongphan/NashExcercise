using ManhPT.EF_Core_Assignment_1.Repository.GenericRepository;

namespace ManhPT.EF_Core_Assignment_1.Service.BaseService
{
    public class BaseService<TEntity, TEntityDto, TEntityCreateDto>(IBaseRepository<TEntity> repository) : IBaseService<TEntityDto, TEntityCreateDto> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository = repository;

        public void DeleteAsync(object Id)
        {
            _repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntityDto> GetByIdAsync(object Id)
        {
            throw new NotImplementedException();
        }

        public void InsertAsync(TEntityCreateDto entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(TEntityCreateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
