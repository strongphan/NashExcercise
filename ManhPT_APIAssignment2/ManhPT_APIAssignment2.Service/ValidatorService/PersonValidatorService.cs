using FluentValidation;
using ManhPT_APIAssignment2.Model;

namespace ManhPT_APIAssignment2.Service.ValidatorService
{
    public class PersonValidatorService : AbstractValidator<Person>, IPersonValidatorService
    {
        public Dictionary<string, string> ValidationErrors { get; private set; }

        public PersonValidatorService()
        {
            ValidationErrors = new Dictionary<string, string>();

            RuleFor(person => person.FirstName)
               .NotEmpty()
               .WithMessage("Please  first name.")
               .MaximumLength(20)
               .WithMessage("Max length is 20.");

            RuleFor(person => person.LastName)
                .NotEmpty()
                .WithMessage("Please  last name.")
                .MaximumLength(20)
                .WithMessage("Max length is 20.");

            RuleFor(person => person.Gender)
                .IsInEnum().WithMessage("Please choose a valid gender.");

            RuleFor(person => person.DOB)
                .NotEmpty().WithMessage("Please choose date of birth.");

            RuleFor(person => person.BirthPlace)
                .NotEmpty().WithMessage("Please fill birth place.")
                .MaximumLength(40).WithMessage("Max length is 40.");
        }
    }
}
