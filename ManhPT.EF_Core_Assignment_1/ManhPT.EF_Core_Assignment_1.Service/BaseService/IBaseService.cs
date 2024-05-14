namespace ManhPT.EF_Core_Assignment_1.Service
{
    public interface IBaseService<TEntityDto, TEntityCreateDto>
    {
        Task<IEnumerable<TEntityDto>> GetAllAsync();
        Task<TEntityDto> GetByIdAsync(Guid Id);
        void InsertAsync(TEntityCreateDto entityDto);
        void UpdateAsync(Guid id, TEntityDto entityDto);
        void DeleteAsync(Guid Id);
    }
}
