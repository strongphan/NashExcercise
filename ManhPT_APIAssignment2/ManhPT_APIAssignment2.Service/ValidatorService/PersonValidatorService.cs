using ManhPT_APIAssignment2.Model;

namespace ManhPT_APIAssignment2.Service.ValidatorService
{
    public class PersonValidatorService : IPersonValidatorService
    {
        public GeneralValidationResult Validate(Person person)
        {
            var modelValidationResult = new GeneralValidationResult();

            //Use Generic validation result in case need to display in message current value
            //var modelValidationResult = new ModelValidationResult<Person> { Content = person };

            var validator = new PersonValidator();
            var validationResult = validator.Validate(person);

            modelValidationResult.IsValid = validationResult.IsValid;
            modelValidationResult.Errors = validationResult.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage);

            return modelValidationResult;
        }
    }
}
