using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository.SalaryRepository;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.SalaryDtos;

namespace ManhPT.EF_Core_Assignment_1.Service.SalaryService
{
    public class SalaryService : BaseService<Salary, SalaryDto, SalaryCreateDto>, ISalaryService
    {
        public SalaryService(ISalaryRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
