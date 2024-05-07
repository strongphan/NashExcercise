using MVCAssignment.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Model
{
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Person(string firstName, string lastName, Gender gender, DateOnly dOB, string phoneNumber, string birthPlace, bool isGraduated)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DOB = dOB;
            PhoneNumber = phoneNumber;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated;
        }

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
