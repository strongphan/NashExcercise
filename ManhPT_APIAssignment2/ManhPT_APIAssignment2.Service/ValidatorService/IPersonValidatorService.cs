
namespace ManhPT_APIAssignment2.Service.ValidatorService
{
    public interface IPersonValidatorService
    {
        Dictionary<string, string> ValidationErrors { get; }
    }
}