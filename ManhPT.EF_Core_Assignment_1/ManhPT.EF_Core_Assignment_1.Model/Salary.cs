using System.ComponentModel.DataAnnotations;

namespace ManhPT.EF_Core_Assignment_1.Model
{

    public class Salary : IHaskey
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public Employee Employee { get; set; }

        public Guid GetKey()
        {
            return Id;
        }
    }
}
