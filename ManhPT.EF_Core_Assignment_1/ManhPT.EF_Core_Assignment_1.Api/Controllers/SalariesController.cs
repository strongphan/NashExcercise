using ManhPT.EF_Core_Assignment_1.Service.DTOs.SalaryDtos;
using ManhPT.EF_Core_Assignment_1.Service.SalaryService;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT.EF_Core_Assignment_1.Api.Controllers
{
    [Route("api/salary")]
    [ApiController]
    public class SalariesController : BaseController<SalaryDto, SalaryCreateDto>
    {
        private readonly ISalaryService _service;

        public SalariesController(ISalaryService service) : base(service)
        {
            _service = service;
        }
    }
}
