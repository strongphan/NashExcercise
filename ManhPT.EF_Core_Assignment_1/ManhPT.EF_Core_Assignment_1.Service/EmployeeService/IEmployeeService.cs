using ManhPT.EF_Core_Assignment_1.Service.DTOs.EmployeeDtos;

namespace ManhPT.EF_Core_Assignment_1.Service.EmployeeService
{
    public interface IEmployeeService : IBaseService<EmployeeDto, EmployeeCreateDto>
    {
        Task<IEnumerable<EmployeeDto>> GetListEmployeeWithDepartmentAsync();
        Task<IEnumerable<EmployeeDto>> GetEmployeesWithProjectsAsync();
        Task<IEnumerable<EmployeeDto>> GetFilterEmployeesAsync();
    }
}
