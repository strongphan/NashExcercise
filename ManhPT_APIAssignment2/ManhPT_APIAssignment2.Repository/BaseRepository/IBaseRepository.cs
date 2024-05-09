
using ManhPT_APIAssignment2.Model;

namespace ManhPT_APIAssignment2.Repository.BaseRepository
{
    public interface IBaseRepository<TEntity>
    {

        public Task<bool> AddAsync(TEntity entity);
        public Task<bool> UpdateAsync(TEntity entity);
        public Task<bool> DeleteAsync(Guid entityId);
        public Task<IEnumerable<TEntity>> GetListAsync(FilterPersonDto filterPersonDTO);
        public Task<Person> GetByIdAsync(Guid entityId);
    }
}