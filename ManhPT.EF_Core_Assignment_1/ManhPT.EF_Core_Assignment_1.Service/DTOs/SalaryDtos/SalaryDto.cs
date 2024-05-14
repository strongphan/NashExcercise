using ManhPT.EF_Core_Assignment_1.Model;

namespace ManhPT.EF_Core_Assignment_1.Service.DTOs.SalaryDtos
{
    public class SalaryDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public Employee Employee { get; set; }
    }
}
