using AutoMapper;
using Moq;
using MVCAssignment.Model;
using MVCAssignment.Repository.DTOs;
using MVCAssignment.Repository.PersonRepository;
using MVCAssignment.Service;
using MVCAssignment.WebApp.Mappers;

namespace ManhPt_UnitTestAssignmen.UnitTest.Services
{
    public class PersonServiceTest
    {
        private PersonService _personService;

        private Mock<IPersonRepository> _personRepository;

        private IMapper _mapper;


        [SetUp]
        public void Setup()
        {
            var profile = new PersonMap();
            var mapperConfig = new MapperConfiguration(c => c.AddProfile(profile));
            _mapper = mapperConfig.CreateMapper();
            _personRepository = new();
            _personService = new PersonService(_personRepository.Object, _mapper);

        }

        [Test]
        public void AddPerson_ValidPersonDto_ReturnsPersonId()
        {
            // Arrange
            var personDto = new PersonDto { };
            var personId = Guid.NewGuid();
            _personRepository.Setup(x => x.AddPerson(It.IsAny<Person>())).Returns(personId);
            // Act
            var result = _personService.AddPerson(personDto);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(personId));
            _personRepository.Verify(x => x.AddPerson(It.IsAny<Person>()), Times.Once());
        }
        [Test]
        public void AddPerson_ValidPersonDto_ReturnsNull()
        {
            // Arrange
            var personDto = new PersonDto { };
            // Act
            var result = _personService.AddPerson(personDto);

            // Assert
            Assert.That(result, Is.Null);
            _personRepository.Verify(x => x.AddPerson(It.IsAny<Person>()), Times.Once());
        }

        [Test]
        public void UpdatePerson_ValidPersonDto_ReturnTrue()
        {
            // Arrange
            var personDto = new PersonDto { };
            _personRepository.Setup(x => x.UpdatePerson(It.IsAny<Person>())).Returns(true);

            // Act
            var result = _personService.UpdatePerson(personDto);

            // Assert
            Assert.That(result, Is.EqualTo(true));
            _personRepository.Verify(x => x.UpdatePerson(It.IsAny<Person>()), Times.Once());
        }
        [Test]
        public void UpdatePerson_InValidPersonDto_ReturnFalse()
        {
            // Arrange
            var personDto = new PersonDto { };
            _personRepository.Setup(x => x.UpdatePerson(It.IsAny<Person>())).Returns(false);

            // Act
            var result = _personService.UpdatePerson(personDto);

            // Assert
            Assert.That(result, Is.EqualTo(false));
            _personRepository.Verify(x => x.UpdatePerson(It.IsAny<Person>()), Times.Once());
        }
        [Test]
        public void DeletePerson_ValidId_ReturnTrue()
        {
            // Arrange
            _personRepository.Setup(x => x.DeletePerson(It.IsAny<Guid>())).Returns(true);
            // Act
            var result = _personService.DeletePerson(Guid.NewGuid());
            // Assert
            Assert.That(result, Is.EqualTo(true));
            _personRepository.Verify(x => x.DeletePerson(It.IsAny<Guid>()), Times.Once());

        }
        [Test]
        public void DeletePerson_InValidId_ReturnFalse()
        {
            // Arrange
            _personRepository.Setup(x => x.DeletePerson(It.IsAny<Guid>())).Returns(false);
            // Act
            var result = _personService.DeletePerson(Guid.NewGuid());
            // Assert
            Assert.That(result, Is.EqualTo(false));
            _personRepository.Verify(x => x.DeletePerson(It.IsAny<Guid>()), Times.Once());

        }
        [Test]
        public void GetPersonById_ValidId_ReturnPersonDto()
        {
            // Arrange
            var person = new Person();
            _personRepository.Setup(x => x.GetPersonById(It.IsAny<Guid>())).Returns(person);
            // Act
            var result = _personService.GetPersonById(person.Id);
            // Assert
            Assert.That(result, Is.Not.Null);
            _personRepository.Verify(x => x.GetPersonById(It.IsAny<Guid>()), Times.Once());
        }
        [Test]
        public void GetPersonById_InValidId_ReturnNull()
        {
            // Arrange
            var person = new Person();
            // Act
            var result = _personService.GetPersonById(person.Id);
            // Assert
            Assert.That(result, Is.Null);
            _personRepository.Verify(x => x.GetPersonById(It.IsAny<Guid>()), Times.Once());
        }
        [Test]
        public void GetPeople_NoCondition_ReturnPeopleDto()
        {
            // Arrange
            var people = new List<Person>();
            _personRepository.Setup(x => x.GetPeople(It.IsAny<FilterPersonDto>())).Returns(people);
            // Act
            var result = _personService.GetPeople(new FilterPersonDto());
            // Assert
            Assert.That(result, Is.Not.Null);
            _personRepository.Verify(x => x.GetPeople(It.IsAny<FilterPersonDto>()), Times.Once());
        }
        [Test]
        public void GetOldestPerson_ReturnOldestPerson()
        {
            // Arrange
            _personRepository.Setup(x => x.GetOldestPerson()).Returns(new Person());
            // Act
            var result = _personService.GetOldestPerson();
            // Assert
            Assert.That(result, Is.Not.Null);
            _personRepository.Verify(x => x.GetOldestPerson(), Times.Once());
        }
        [Test]
        public void GetFulName_ReturnFullName()
        {
            // Arrange
            List<string> fullName = [string.Empty];
            _personRepository.Setup(x => x.GetFulName()).Returns(fullName);
            // Act
            var result = _personService.GetFulName();
            // Assert
            Assert.That(result, Is.Not.Null);
            _personRepository.Verify(x => x.GetFulName(), Times.Once());
        }
    }
}