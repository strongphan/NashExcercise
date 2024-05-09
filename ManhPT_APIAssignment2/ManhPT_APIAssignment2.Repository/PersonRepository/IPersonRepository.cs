using ManhPT_APIAssignment2.Model;

namespace ManhPT_APIAssignment2.Repository.PersonRepository
{
    public interface IPersonRepository
    {
        public Task<bool> AddPersonAsync(Person person);
        public Task<bool> UpdatePersonAsync(Person person);
        public Task<bool> DeletePersonAsync(Guid personId);
        public Task<IEnumerable<Person>> GetPeopleAsync(FilterPersonDto filterPersonDTO);
        public Task<Person> GetPersonByIdAsync(Guid personId);
    }
}
