using ManhPT.EF_Core_Assignment_1.Model;

namespace ManhPT.EF_Core_Assignment_1.Service.DTOs.ProjectEmployeeDtos
{
    public class ProjectEmployeeDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public bool Enable { get; set; }
        public Project Project { get; set; }
        public Employee Employee { get; set; }
    }
}
