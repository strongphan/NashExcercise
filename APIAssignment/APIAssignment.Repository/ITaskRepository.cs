using APIAssignment.Model;

namespace APIAssignment.Repository
{
    public interface ITaskRepository
    {
        public Task GetListTask();
        public Task GetTaskById(Guid Id);
        public Task CreateTask(Excercise task);
        public Task UpdateTask(Excercise task);
        public Task DeleteTask(Guid Id);
    }
}