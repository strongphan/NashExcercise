using MVCAssignment.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Repository.DTOs
{
    public class PersonDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateOnly DOB { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string BirthPlace { get; set; }

        public bool IsGraduated { get; set; } = false;
    }
}
