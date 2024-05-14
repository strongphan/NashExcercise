using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository.ProjectRepository;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.ProjectDto;

namespace ManhPT.EF_Core_Assignment_1.Service.ProjectService
{
    public class ProjectService : BaseService<Project, ProjectDto, ProjectCreateDto>, IProjectService
    {
        public ProjectService(IProjectRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
