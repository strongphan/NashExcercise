using ManhPT_APIAssignment2.Model;
using ManhPT_APIAssignment2.Repository;
using ManhPT_APIAssignment2.Repository.PersonRepository;
using ManhPT_APIAssignment2.Service.ValidatorService;

namespace ManhPT_APIAssignment2.Service.PersonService
{
    public class PersonService(
        IPersonRepository repository,
        IPersonValidatorService validatorService) : IPersonService
    {
        private readonly IPersonRepository _repository = repository;
        private readonly IPersonValidatorService _validatorService = validatorService;

        public async Task<GeneralResponse> AddPersonAsync(Person person)
        {
            var response = new GeneralResponse();

            var validationResult = _validatorService.Validate(person);
            if (!validationResult.IsValid)
            {
                response.ValidationResult = validationResult;
                return response;
            }

            person.Id = Guid.NewGuid();
            await _repository.AddPersonAsync(person);

            response.Success = true;
            return response;
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

        public async Task<GeneralResponse> UpdatePersonAsync(Person person)
        {
            var response = new GeneralResponse();

            var validationResult = _validatorService.Validate(person);
            if (!validationResult.IsValid)
            {
                response.ValidationResult = validationResult;
                return response;
            }

            person.Id = Guid.NewGuid();
            await _repository.UpdatePersonAsync(person);

            response.Success = true;
            return response;
        }
    }
}
