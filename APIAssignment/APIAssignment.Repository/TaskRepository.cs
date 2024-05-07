using APIAssignment.Model;

namespace APIAssignment.Repository
{

    public class TaskRepository : ITaskRepository
    {
        public static readonly List<Excercise> tasks = [];
        public Task CreateTask(Excercise task)
        {
            tasks.Add(task);
            return Task.CompletedTask;
        }

        public Task DeleteTask(Guid Id)
        {
            try
            {
                tasks.Remove()
            }
            catch (Exception ex)
            {
            }
        }

        public Task GetListTask()
        {
            throw new NotImplementedException();
        }

        public async Task<Excercise> GetTaskById(Guid taskId)
        {
            try
            {
                var excercise = tasks.FirstOrDefault(t => t.Id == taskId);

                if (excercise == null)
                {
                    throw new Exception("Have some bug");
                }
                else
                {
                    return excercise;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public Task UpdateTask(Excercise task)
        {
            throw new NotImplementedException();
        }
    }
}
