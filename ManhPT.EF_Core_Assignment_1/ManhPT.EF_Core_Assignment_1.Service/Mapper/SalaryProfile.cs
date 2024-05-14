using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.SalaryDtos;

namespace ManhPT.EF_Core_Assignment_1.Service.Mapper
{
    public class SalaryProfile : Profile
    {
        public SalaryProfile()
        {
            CreateMap<Salary, SalaryDto>();
            CreateMap<SalaryDto, Salary>();
            CreateMap<SalaryCreateDto, Salary>()
                .ForMember(m => m.Id, o => o.MapFrom(s => Guid.NewGuid()));
        }

    }
}
