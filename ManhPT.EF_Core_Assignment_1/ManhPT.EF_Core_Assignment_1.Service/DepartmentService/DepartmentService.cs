using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository.DepartmentRepository;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.DepartmentDtos;

namespace ManhPT.EF_Core_Assignment_1.Service.DepartmentService
{
    public class DepartmentService : BaseService<Department, DepartmentDto, DepartmentCreateDto>, IDepartmentService
    {
        public DepartmentService(IDepartmentRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
