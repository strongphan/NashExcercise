using ManhPT_APIAssignment2.Model;

namespace ManhPT_APIAssignment2.Repository.BaseRepository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        public virtual List<TEntity> list { get; set; }
        public Task<bool> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetListAsync(FilterPersonDto filterPersonDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByIdAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }


    }


}
