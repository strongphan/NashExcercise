using ManhPT_APIAssignment.Model;
using ManhPT_APIAssignment.Repository.ExcerciseRepository;

namespace ManhPT_APIAssignment.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateToDoAsync(ToDo task)
        {
            return await _repository.CreateToDoAsync(task);
        }
        public async Task<bool> CreateToDoBulkAsync(IEnumerable<ToDo> tasks)
        {
            return await _repository.CreateToDoBulkAsync(tasks);
        }

        public async Task<bool> UpdateToDoAsync(ToDo task)
        {
            return await _repository.UpdateToDoAsync(task);
        }

        public async Task<bool> DeleteToDoAsync(Guid Id)
        {
            return await _repository.DeleteToDoAsync(Id);
        }

        public async Task<ToDo> GetToDoByIdAsync(Guid Id)
        {
            return await _repository.GetToDoByIdAsync(Id);
        }

        public async Task<IEnumerable<ToDo>> GetListToDoAsync()
        {
            return await _repository.GetListToDoAsync();
        }
        public async Task<bool> DeleteToDoBulkAsync(IEnumerable<Guid> ids)
        {
            return await _repository.DeleteToDoBulkAsync(ids);
        }
    }
}
