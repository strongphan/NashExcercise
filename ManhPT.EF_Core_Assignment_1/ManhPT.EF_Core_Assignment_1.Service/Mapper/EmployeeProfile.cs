using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.EmployeeDtos;

namespace ManhPT.EF_Core_Assignment_1.Service.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeCreateDto, Employee>()
                .ForMember(m => m.Id, o => o.MapFrom(s => Guid.NewGuid()));
        }
    }
}
