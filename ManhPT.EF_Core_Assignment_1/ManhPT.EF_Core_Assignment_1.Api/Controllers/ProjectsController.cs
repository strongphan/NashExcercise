using ManhPT.EF_Core_Assignment_1.Service.DTOs.ProjectDto;
using ManhPT.EF_Core_Assignment_1.Service.ProjectService;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT.EF_Core_Assignment_1.Api.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectsController : BaseController<ProjectDto, ProjectCreateDto>
    {
        private readonly IProjectService _service;

        public ProjectsController(IProjectService service) : base(service)
        {
            _service = service;
        }
    }
}
