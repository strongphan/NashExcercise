using System.ComponentModel.DataAnnotations;

namespace ManhPT.EF_Core_Assignment_1.Service.DTOs.SalaryDtos
{
    public class SalaryCreateDto
    {
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
