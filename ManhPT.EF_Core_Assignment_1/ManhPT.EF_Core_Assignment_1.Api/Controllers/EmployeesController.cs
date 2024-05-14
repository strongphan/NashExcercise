using ManhPT.EF_Core_Assignment_1.Service.DTOs.EmployeeDtos;
using ManhPT.EF_Core_Assignment_1.Service.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT.EF_Core_Assignment_1.Api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeesController : BaseController<EmployeeDto, EmployeeCreateDto>
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service) : base(service)
        {
            _service = service;
        }
        [HttpGet("department")]
        public async Task<IActionResult> GetListEmployeeWithDepartmentAsync()
        {
            var dtos = await _service.GetListEmployeeWithDepartmentAsync();
            return Ok(dtos);
        }
        [HttpGet("project")]
        public async Task<IActionResult> GetEmployeesWithProjectsAsync()
        {
            var dtos = await _service.GetEmployeesWithProjectsAsync();
            return Ok(dtos);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilterEmployeesAsync()
        {
            var dtos = await _service.GetFilterEmployeesAsync();
            return Ok(dtos);
        }
    }
}
