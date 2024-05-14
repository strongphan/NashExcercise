using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.ProjectEmployeeDtos;

namespace ManhPT.EF_Core_Assignment_1.Service.Mapper
{
    public class ProjectEmployeeProfile : Profile
    {
        public ProjectEmployeeProfile()
        {
            CreateMap<ProjectEmployee, ProjectEmployeeDto>();
            CreateMap<ProjectEmployeeDto, ProjectEmployee>();
            CreateMap<ProjectEmployeeCreateDto, ProjectEmployee>()
                .ForMember(m => m.Id, o => o.MapFrom(s => Guid.NewGuid()));
        }
    }
}
