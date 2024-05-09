using ManhPT_APIAssignment2.Model;
using ManhPT_APIAssignment2.Repository;
using ManhPT_APIAssignment2.Repository.PersonRepository;
using ManhPT_APIAssignment2.Service.ValidatorService;

namespace ManhPT_APIAssignment2.Service.PersonService
{
    public class PersonService(IPersonRepository repository, IPersonValidatorService validatorService) : IPersonService

    {
        private readonly IPersonRepository _repository = repository;
        private readonly IPersonValidatorService _validatorService = validatorService;

        public async Task<bool> AddPersonAsync(Person person)
        {
            var validator = new PersonValidatorService();
            var validationResult = validator.Validate(person);
            var ValidationErrors = new Dictionary<string, string>();
            if (!validationResult.IsValid)
            {
                // Handle validation errors
                var errors = validationResult.Errors;
                foreach (var error in errors)
                {
                    ValidationErrors.Add(error.PropertyName, error.ErrorMessage);
                }
                var s = string.Join(", ", ValidationErrors.Select(e => $"{e.Key}: {e.Value}"));
                return false;
            }
            return await _repository.AddPersonAsync(person);
        }

        public async Task<bool> DeletePersonAsync(Guid personId)
        {
            return await _repository.DeletePersonAsync(personId);
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync(FilterPersonDto filterPersonDTO)
        {
            var people = await _repository.GetPeopleAsync(filterPersonDTO);
            return people;
        }

        public async Task<Person> GetPersonByIdAsync(Guid personId)
        {
            var person = await _repository.GetPersonByIdAsync(personId);
            return person;
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            return await _repository.UpdatePersonAsync(person);
        }
    }
}
