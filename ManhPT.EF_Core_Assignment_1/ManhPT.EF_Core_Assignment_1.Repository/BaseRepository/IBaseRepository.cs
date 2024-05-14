namespace ManhPT.EF_Core_Assignment_1.Repository.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid Id);
        void InsertAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(Guid Id);
        void Save();
    }
}
