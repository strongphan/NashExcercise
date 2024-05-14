using AutoMapper;
using MVCAssignment.Model;
using MVCAssignment.Repository.DTOs;
using MVCAssignment.Repository.PersonRepository;

namespace MVCAssignment.Service
{
    public class PersonService(IPersonRepository repository, IMapper mapper) : IPersonService
    {
        private readonly IPersonRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public Guid? AddPerson(PersonDto dto)
        {
            try
            {
                dto.Id = Guid.NewGuid();
                var person = _mapper.Map<Person>(dto);
                return _repository.AddPerson(person);
            }
            catch (Exception ex)
            {
                throw new Exception("Have some fun :))) " + ex.Message);
            }
        }
        public bool UpdatePerson(PersonDto dto)
        {
            try
            {
                var person = _mapper.Map<Person>(dto);

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

        public List<PersonDto> GetPeople(FilterPersonDto filterPersonDTO)
        {
            try
            {
                var people = _repository.GetPeople(filterPersonDTO);
                var lDto = _mapper.Map<List<PersonDto>>(people);
                return lDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Have some fun :))) " + ex.Message);
            }
        }

        public PersonDto GetOldestPerson()
        {
            try
            {

                var person = _repository.GetOldestPerson();
                var dto = _mapper.Map<PersonDto>(person);
                return dto;
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

        public PersonDto GetPersonById(Guid personId)
        {
            try
            {
                var person = _repository.GetPersonById(personId);
                var dto = _mapper.Map<PersonDto>(person);

                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception("Have some fun :))) " + ex.Message);
            }
        }
    }
}
