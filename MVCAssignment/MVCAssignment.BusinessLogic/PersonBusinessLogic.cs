using MVCAssignment.Model;
using MVCAssignment.Repository.DTOs;
using MVCAssignment.Repository.PersonRepository;

namespace MVCAssignment.BusinessLogic
{
    public class PersonBusinessLogic : IPersonBusinessLogic
    {
        private readonly IPersonRepository _repository;

        public PersonBusinessLogic(IPersonRepository repository)
        {
            _repository = repository;
        }
        public Guid? AddPerson(Person person)
        {
            try
            {
                return _repository.AddPerson(person);
            }
            catch (Exception ex)
            {
                throw new Exception("Have some fun :))) " + ex.Message);
            }
        }
        public bool UpdatePerson(Person person)
        {
            try
            {
                return _repository.UpdatePerson(person);
            }
            catch (Exception ex)
            {
                throw new Exception("Have some fun :))) " + ex.Message);
            }
        }
        public bool DeletePerson(Guid personId)
        {
            try
            {
                return _repository.DeletePerson(personId);
            }
            catch (Exception ex)
            {
                throw new Exception("Have some fun :))) " + ex.Message);
            }
        }

        public List<Person> GetPeople(FilterPersonDto filterPersonDTO)
        {
            try
            {
                return _repository.GetPeople(filterPersonDTO);
            }
            catch (Exception ex)
            {
                throw new Exception("Have some fun :))) " + ex.Message);
            }
        }

        public Person GetOldestPerson()
        {
            try
            {
                return _repository.GetOldestPerson();
            }
            catch (Exception ex)
            {
                throw new Exception("Have some fun :))) " + ex.Message);
            }
        }

        public List<string> GetFulName()
        {
            try
            {
                return _repository.GetFulName();
            }
            catch (Exception ex)
            {
                throw new Exception("Have some fun :))) " + ex.Message);
            }
        }
    }
}
