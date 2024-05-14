using ManhPT.EF_Core_Assignment_1.Model;
using Microsoft.EntityFrameworkCore;

namespace ManhPT.EF_Core_Assignment_1.Repository.BaseRepository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected BusinessContext _context = null;
        protected DbSet<TEntity> _table = null;
        public BaseRepository(BusinessContext dbContext)
        {
            _context = dbContext;
            _table = _context.Set<TEntity>();
        }
        public void DeleteAsync(Guid Id)
        {
            var t = _table.Find(Id);
            if (t != null)
            {
                _table.Remove(t);
                Save();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _table.ToList();
        }

        public async Task<TEntity> GetByIdAsync(Guid Id)
        {
            return await _table.FindAsync(Id);
        }

        public void InsertAsync(TEntity entity)
        {
            _table.Add(entity);
            Save();
        }

        public void UpdateAsync(TEntity entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
