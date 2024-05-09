using ManhPT_APIAssignment2.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace ManhPT_APIAssignment2.API.DTOs
{
    public class PersonDto
    {
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
