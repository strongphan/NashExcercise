using ManhPT_APIAssignment.Model;

namespace ManhPT_APIAssignment.Repository.ExcerciseRepository
{


    public class ToDoRepository : IToDoRepository
    {
        public static readonly List<ToDo> tasks = [];

        public async Task<IEnumerable<ToDo>> GetListToDoAsync()
        {
            return tasks;
        }

        public async Task<ToDo> GetToDoByIdAsync(Guid Id)
        {
            try
            {
                var excercise = tasks.FirstOrDefault(t => t.Id == Id);

                if (excercise == null)
                {
                    return null;
                }
                else
                {
                    return excercise;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CreateToDoAsync(ToDo task)
        {
            try
            {
                tasks.Add(task);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public async Task<bool> CreateToDoBulkAsync(IEnumerable<ToDo> toDoList)
        {
            try
            {
                tasks.AddRange(toDoList);
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false;
            }
        }
        public async Task<bool> UpdateToDoAsync(ToDo task)
        {
            try
            {
                var res = await GetToDoByIdAsync(task.Id); ;

                tasks.Remove(res);

                tasks.Add(task);

                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public async Task<bool> DeleteToDoAsync(Guid Id)
        {
            try
            {
                var res = await GetToDoByIdAsync(Id); ;
                tasks.Remove(res);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public async Task<bool> DeleteToDoBulkAsync(IEnumerable<Guid> ids)
        {
            try
            {
                var tasksToDelete = tasks.Where(t => ids.Contains(t.Id)).ToList();
                foreach (var task in tasksToDelete)
                {
                    tasks.Remove(task);
                }
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false;
            }
        }
    }
}
