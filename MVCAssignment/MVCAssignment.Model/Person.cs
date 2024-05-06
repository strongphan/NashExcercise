using MVCAssignment.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Model
{
    public class Person
    {
        [Required]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public bool IsGraduated { get; set; }
    }
}
