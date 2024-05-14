using ManhPT.EF_Core_Assignment_1.Model;

namespace ManhPT.EF_Core_Assignment_1.Service.DTOs.EmployeeDtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime JoinedDate { get; set; }
        public Department Department { get; set; }
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
        public Salary Salary { get; set; }
    }
}
