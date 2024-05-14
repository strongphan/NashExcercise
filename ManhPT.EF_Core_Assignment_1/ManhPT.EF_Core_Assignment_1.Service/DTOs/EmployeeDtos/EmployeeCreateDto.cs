using System.ComponentModel.DataAnnotations;

namespace ManhPT.EF_Core_Assignment_1.Service.DTOs.EmployeeDtos
{
    public class EmployeeCreateDto
    {
        [Required]
        public string Name { get; set; }
        public Guid? DepartmentId { get; set; }
        [Required]
        public DateTime JoinedDate { get; set; }

    }
}
