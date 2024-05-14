using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository.BaseRepository;

namespace ManhPT.EF_Core_Assignment_1.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetListEmployeeWithDepartmentAsync();
        Task<IEnumerable<Employee>> GetEmployeesWithProjectsAsync();
        Task<IEnumerable<Employee>> GetFilterEmployeesAsync();
    }
}
