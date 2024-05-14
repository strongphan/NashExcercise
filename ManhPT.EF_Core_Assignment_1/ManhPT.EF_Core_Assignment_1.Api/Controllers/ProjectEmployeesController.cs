using ManhPT.EF_Core_Assignment_1.Service.DTOs.ProjectEmployeeDtos;
using ManhPT.EF_Core_Assignment_1.Service.ProjectEmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT.EF_Core_Assignment_1.Api.Controllers
{
    [Route("api/project_employee")]
    [ApiController]
    public class ProjectEmployeesController : BaseController<ProjectEmployeeDto, ProjectEmployeeCreateDto>
    {
        private readonly IProjectEmployeeService _service;

        public ProjectEmployeesController(IProjectEmployeeService service) : base(service)
        {
            _service = service;
        }
    }
}
