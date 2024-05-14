using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository.ProjectEmployeeRepository;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.ProjectEmployeeDtos;

namespace ManhPT.EF_Core_Assignment_1.Service.ProjectEmployeeService
{
    public class ProjectEmployeeService : BaseService<ProjectEmployee, ProjectEmployeeDto, ProjectEmployeeCreateDto>, IProjectEmployeeService
    {
        public ProjectEmployeeService(IProjectEmployeeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
