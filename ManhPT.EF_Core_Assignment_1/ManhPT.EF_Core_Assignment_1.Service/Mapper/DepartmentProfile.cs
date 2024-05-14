using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.DepartmentDtos;

namespace ManhPT.EF_Core_Assignment_1.Service.Mapper
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<DepartmentCreateDto, Department>()
                .ForMember(m => m.Id, o => o.MapFrom(s => Guid.NewGuid()));
        }
    }
}
