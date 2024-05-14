using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.ProjectDto;

namespace ManhPT.EF_Core_Assignment_1.Service.Mapper
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();
            CreateMap<ProjectCreateDto, Project>()
                .ForMember(m => m.Id, o => o.MapFrom(s => Guid.NewGuid()));
        }
    }
}
