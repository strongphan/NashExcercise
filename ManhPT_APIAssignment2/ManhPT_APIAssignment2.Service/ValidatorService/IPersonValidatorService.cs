
using ManhPT_APIAssignment2.Model;

namespace ManhPT_APIAssignment2.Service.ValidatorService
{
    public interface IPersonValidatorService
    {
        GeneralValidationResult Validate(Person person);
    }
}