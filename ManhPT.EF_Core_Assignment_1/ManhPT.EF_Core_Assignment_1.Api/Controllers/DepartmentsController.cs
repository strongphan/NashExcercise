using ManhPT.EF_Core_Assignment_1.Service.DepartmentService;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.DepartmentDtos;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT.EF_Core_Assignment_1.Api.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentsController : BaseController<DepartmentDto, DepartmentCreateDto>
    {
        private readonly IDepartmentService _service;

        public DepartmentsController(IDepartmentService service) : base(service)
        {
            _service = service;
        }
    }
}
