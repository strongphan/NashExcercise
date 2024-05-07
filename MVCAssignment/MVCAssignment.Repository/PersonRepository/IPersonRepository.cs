using MVCAssignment.Model;
using MVCAssignment.Repository.DTOs;

namespace MVCAssignment.Repository.PersonRepository
{
    public interface IPersonRepository
    {
        public Guid? AddPerson(Person person);
        public bool UpdatePerson(Person person);
        public bool DeletePerson(Guid personId);
        public List<Person> GetPeople(FilterPersonDto filterPersonDTO);
        public Person GetOldestPerson();
        public List<string> GetFulName();
        public Person GetPersonById(Guid personId);
    }
}
