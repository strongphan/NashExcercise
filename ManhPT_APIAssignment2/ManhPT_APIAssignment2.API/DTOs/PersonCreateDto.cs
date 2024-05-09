using ManhPT_APIAssignment2.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace ManhPT_APIAssignment2.API.DTOs
{
    public class PersonCreateDto
    {
        [Required(ErrorMessage = "Please fill first name.")]
        [MaxLength(20, ErrorMessage = "Max length is 20.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please fill last name.")]
        [MaxLength(20, ErrorMessage = "Max length is 20.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please choose gender.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please choose date of birth.")]
        [DateNotInFuture]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please fill birth place.")]
        [MaxLength(40, ErrorMessage = "Max length is 40.")]
        public string BirthPlace { get; set; }
    }
    public class DateNotInFutureAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dateOfBirth = (DateTime)value;
                if (dateOfBirth.Date > DateTime.Now.Date)
                {
                    return new ValidationResult("Date of birth cannot be in the future.");
                }
            }
            return ValidationResult.Success;
        }
    }

}
