using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.DepartmentDtos;

namespace ManhPT.EF_Core_Assignment_1.Service.Mapper
{
    public class DepartmentProfile : Profile
    {
        protected DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentCreateDto, Department>();
        }
    }
}
