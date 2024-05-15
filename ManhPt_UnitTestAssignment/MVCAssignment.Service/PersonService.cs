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

            dto.Id = Guid.NewGuid();
            var person = _mapper.Map<Person>(dto);
            return _repository.AddPerson(person);


        }
        public bool UpdatePerson(PersonDto dto)
        {

            var person = _mapper.Map<Person>(dto);

            return _repository.UpdatePerson(person);

        }
        public bool DeletePerson(Guid personId)
        {

            return _repository.DeletePerson(personId);

        }

        public List<PersonDto> GetPeople(FilterPersonDto filterPersonDTO)
        {

            var people = _repository.GetPeople(filterPersonDTO);
            var lDto = _mapper.Map<List<PersonDto>>(people);
            return lDto;

        }

        public PersonDto GetOldestPerson()
        {


            var person = _repository.GetOldestPerson();
            var dto = _mapper.Map<PersonDto>(person);
            return dto;

        }

        public List<string> GetFulName()
        {

            return _repository.GetFulName();

        }

        public PersonDto GetPersonById(Guid personId)
        {

            var person = _repository.GetPersonById(personId);
            var dto = _mapper.Map<PersonDto>(person);

            return dto;

        }
    }
}
