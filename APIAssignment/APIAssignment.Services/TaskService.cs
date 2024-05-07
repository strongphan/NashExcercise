using APIAssignment.Model;
using APIAssignment.Repository;

namespace APIAssignment.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public Task CreateTask(Excercise task)
        {
            try
            {
                _repository.CreateTask(task);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
