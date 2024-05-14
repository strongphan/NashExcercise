using System.ComponentModel.DataAnnotations;

namespace ManhPT.EF_Core_Assignment_1.Service.DTOs.ProjectEmployeeDtos
{
    public class ProjectEmployeeCreateDto
    {
        [Required]
        public Guid ProjectId { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }
        public bool Enable { get; set; }
    }
}
