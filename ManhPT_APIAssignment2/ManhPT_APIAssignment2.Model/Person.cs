using ManhPT_APIAssignment2.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace ManhPT_APIAssignment2.Model
{
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Person(string firstName, string lastName, Gender gender, DateTime dOB, string birthPlace)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DOB = dOB;
            BirthPlace = birthPlace;
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
        public DateTime DOB { get; set; }

        [Required]
        public string BirthPlace { get; set; }

    }
}
