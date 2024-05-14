using MVCAssignment.Repository.DTOs;

namespace MVCAssignment.Service
{
    public interface IPersonService
    {
        public Guid? AddPerson(PersonDto person);
        public bool UpdatePerson(PersonDto person);
        public bool DeletePerson(Guid personId);
        public List<PersonDto> GetPeople(FilterPersonDto filterPersonDTO);
        public PersonDto GetPersonById(Guid personId);
        public PersonDto GetOldestPerson();
        public List<string> GetFulName();
    }
}
