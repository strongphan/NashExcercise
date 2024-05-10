namespace ManhPT.EF_Core_Assignment_1.Repository.GenericRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object Id);
        void InsertAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(object Id);
        void Save();
    }
}
