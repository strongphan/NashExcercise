using ManhPT.EF_Core_Assignment_1.Model;
using Microsoft.EntityFrameworkCore;

namespace ManhPT.EF_Core_Assignment_1.Repository.GenericRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private BusinessContext _context = null;
        private DbSet<TEntity> _table = null;
        public BaseRepository()
        {
            _context = new BusinessContext();
            _table = _context.Set<TEntity>();
        }
        public void DeleteAsync(object Id)
        {
            var t = _table.Find(Id);
            if (t != null)
            {
                _table.Remove(t);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _table.ToList();
        }

        public async Task<TEntity> GetByIdAsync(object Id)
        {
            return await _table.FindAsync(Id);
        }

        public void InsertAsync(TEntity entity)
        {
            _table.Add(entity);
        }

        public void UpdateAsync(TEntity entity)
        {
            _table.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
