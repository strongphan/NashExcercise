using ManhPT.EF_Core_Assignment_1.Model;

namespace ManhPT.EF_Core_Assignment_1.Service.DTOs.DepartmentDtos
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
