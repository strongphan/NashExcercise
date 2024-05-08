using ManhPT_APIAssignment.Model;

namespace ManhPT_APIAssignment.Services
{
    public interface IToDoService
    {
        public Task<IEnumerable<ToDo>> GetListToDoAsync();
        public Task<ToDo> GetToDoByIdAsync(Guid Id);
        public Task<bool> CreateToDoAsync(ToDo task);
        public Task<bool> CreateToDoBulkAsync(IEnumerable<ToDo> tasks);
        public Task<bool> UpdateToDoAsync(ToDo task);
        public Task<bool> DeleteToDoAsync(Guid Id);
        public Task<bool> DeleteToDoBulkAsync(IEnumerable<Guid> ids);

    }
}