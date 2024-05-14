using AutoMapper;
using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository;
using ManhPT.EF_Core_Assignment_1.Service.DTOs.EmployeeDtos;

namespace ManhPT.EF_Core_Assignment_1.Service.EmployeeService
{
    public class EmployeeService : BaseService<Employee, EmployeeDto, EmployeeCreateDto>, IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesWithProjectsAsync()
        {
            var employees = await _repository.GetEmployeesWithProjectsAsync();
            var dtos = _mapper.Map<List<EmployeeDto>>(employees);
            return dtos;
        }

        public async Task<IEnumerable<EmployeeDto>> GetFilterEmployeesAsync()
        {
            var employees = await _repository.GetFilterEmployeesAsync();
            var dtos = _mapper.Map<List<EmployeeDto>>(employees);
            return dtos;
        }

        public async Task<IEnumerable<EmployeeDto>> GetListEmployeeWithDepartmentAsync()
        {
            var employees = await _repository.GetListEmployeeWithDepartmentAsync();
            var dtos = _mapper.Map<List<EmployeeDto>>(employees);
            return dtos;
        }

    }
}
