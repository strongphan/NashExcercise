namespace ManhPT.EF_Core_Assignment_1.Service.BaseService
{
    public interface IBaseService<TEntityDto, TEntityCreateDto>
    {
        Task<IEnumerable<TEntityDto>> GetAllAsync();
        Task<TEntityDto> GetByIdAsync(object Id);
        void InsertAsync(TEntityCreateDto entity);
        void UpdateAsync(TEntityCreateDto entity);
        void DeleteAsync(object Id);
    }
}
