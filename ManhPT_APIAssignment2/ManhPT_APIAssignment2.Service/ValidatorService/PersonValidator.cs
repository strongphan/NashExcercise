using FluentValidation;
using ManhPT_APIAssignment2.Model;

namespace ManhPT_APIAssignment2.Service.ValidatorService
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.FirstName)
               .NotEmpty()
               .WithMessage("Please fill first name.")
               .MaximumLength(20)
               .WithMessage("Max length is 20.");

            RuleFor(person => person.LastName)
                .NotEmpty()
                .WithMessage("Please fill last name.")
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
