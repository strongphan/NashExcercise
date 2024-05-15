using Microsoft.AspNetCore.Mvc;
using Moq;
using MVC_.NET_Core_Assignment_1.Areas.NashTech.Controllers;
using MVCAssignment.Model.Enum;
using MVCAssignment.Repository.DTOs;
using MVCAssignment.Service;
using MVCAssignment.WebApp.NormalSevice;

namespace ManhPt_UnitTestAssignmen.UnitTest.Controllers
{
    public class PersonControllerTest
    {
        private PersonController _personController;

        private readonly Mock<IPersonService> _personService = new();
        private readonly Mock<IExcelService> _excelService = new();
        [SetUp]
        public void SetUp()
        {
            _personController = new PersonController(_personService.Object, _excelService.Object);
        }
        [TearDown]
        public void TearDown()
        {
            _personController.Dispose();
        }
        [Test]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            //arrange
            var peopleDto = new List<PersonDto>();
            _personService.Setup(x => x.GetPeople(It.IsAny<FilterPersonDto>())).Returns(peopleDto);

            //Act
            var result = _personController.Index();

            //Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void Detail_ValidId_ReturnsViewForDetail()
        {
            // Arrange
            var personId = Guid.NewGuid();
            _personService.Setup(x => x.GetPersonById(personId)).Returns(new PersonDto { Id = personId });

            // Act
            var result = _personController.Detail(personId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
        [Test]
        public void Detail_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var personId = Guid.NewGuid();

            // Act
            var result = _personController.Detail(personId);

            // Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
        [Test]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            //arrange
            var result = _personController.Create();

            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
        [Test]
        public void Create_InvalidModelState_ReturnsView()
        {
            //Arrange
            _personController.ModelState.AddModelError("FirstName", "First name is required");
            var person = new PersonDto { LastName = "as", PhoneNumber = "848635623" };

            //Act
            var result = _personController.Create(person);


            Assert.That(result, Is.InstanceOf<ViewResult>());
            _personService.Verify(x => x.AddPerson(It.IsAny<PersonDto>()), Times.Never);
        }
        [Test]
        public void Create_ValidModelState_ReturnsRedirect()
        {
            //Arrange
            PersonDto? dto = null;

            _personService.Setup(p => p.AddPerson(It.IsAny<PersonDto>())).Callback<PersonDto>(p => dto = p);

            PersonDto person = new()
            {
                FirstName = "Manh",
                LastName = "Phan",
                Gender = Gender.Male,
                DOB = new DateOnly(2002, 02, 22),
                PhoneNumber = "0975169602",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            };

            //Act
            var result = _personController.Create(person);

            _personService.Verify(x => x.AddPerson(It.IsAny<PersonDto>()), Times.Once);

            //Assert
            Assert.That(person.LastName, Is.EqualTo(dto.LastName));
            Assert.IsAssignableFrom<RedirectToActionResult>(result);
            var redirectToActionResult = (RedirectToActionResult)result;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Update_ValidId_ReturnsViewForUpdate()
        {
            //arrange
            var personId = Guid.NewGuid();
            _personService.Setup(x => x.GetPersonById(personId)).Returns(new PersonDto { Id = personId });
            //Act
            var result = _personController.Edit(personId);
            //Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void Update_InvalidId_ReturnsNotFound()
        {
            //arrange
            var personId = Guid.NewGuid();

            //Act
            var result = _personController.Edit(personId);

            //Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
        [Test]
        public void Update_InvalidModelState_ReturnsView()
        {
            //Arrange
            _personController.ModelState.AddModelError("FirstName", "First name is required");
            var person = new PersonDto { LastName = "as", PhoneNumber = "848635623" };

            //Act
            var result = _personController.Edit(person);


            Assert.That(result, Is.InstanceOf<ViewResult>());
            _personService.Verify(x => x.UpdatePerson(It.IsAny<PersonDto>()), Times.Never);
        }
        [Test]
        public void Update_ValidModelState_ReturnsRedirect()
        {
            //Arrange
            PersonDto? dto = null;

            _personService.Setup(p => p.UpdatePerson(It.IsAny<PersonDto>())).Callback<PersonDto>(p => dto = p);

            PersonDto person = new()
            {
                FirstName = "Manh",
                LastName = "Phan",
                Gender = Gender.Male,
                DOB = new DateOnly(2002, 02, 22),
                PhoneNumber = "0975169602",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            };

            //Act
            var result = _personController.Edit(person);


            //Assert
            _personService.Verify(x => x.UpdatePerson(It.IsAny<PersonDto>()), Times.Once);
            Assert.That(person.LastName, Is.EqualTo(dto.LastName));
            Assert.IsAssignableFrom<RedirectToActionResult>(result);
            var redirectToActionResult = (RedirectToActionResult)result;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));
        }
        [Test]
        public void Delete_ValidId_ReturnsView()
        {
            //arrange
            var personId = Guid.NewGuid();
            _personService.Setup(x => x.GetPersonById(personId)).Returns(new PersonDto { Id = personId });
            //Act
            var result = _personController.Delete(personId);
            //Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            _personService.Verify(x => x.DeletePerson(It.IsAny<Guid>()), Times.Once);

        }
        [Test]
        public void Delete_ValidId_ReturnsNotFound()
        {
            //arrange
            var personId = Guid.NewGuid();
            //Act
            var result = _personController.Delete(personId);
            //Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
            _personService.Verify(x => x.DeletePerson(It.IsAny<Guid>()), Times.Never);

        }
        [Test]
        public void GetMales_ReturnsView()
        {
            //Act
            var result = _personController.GetMales();

            //Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());

        }
        [Test]
        public void Get2000_ReturnsView()
        {
            //Act
            var result = _personController.Get2000();

            //Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());

        }
        [Test]
        public void GetBefore2000_ReturnsView()
        {
            //Act
            var result = _personController.GetBefore2000();

            //Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());

        }
        [Test]
        public void GetAfter2000_ReturnsView()
        {
            //Act
            var result = _personController.GetAfter2000();

            //Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
        [Test]
        public void GetOldest_ReturnsView()
        {
            //Act
            var result = _personController.GetOldest();

            //Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
        [Test]
        public void GetFullName_ReturnsView()
        {
            //Act
            var result = _personController.GetFullName();

            //Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
        [Test]
        public void ExportExcel_ActionExecutes_ReturnsFileResult()
        {
            // Arrange
            var peopleDto = new List<PersonDto>();
            _personService.Setup(x => x.GetPeople(It.IsAny<FilterPersonDto>())).Returns(peopleDto);
            var excelContent = new byte[] { 0x01, 0x02, 0x03 };

            _ = _excelService.Setup(expression: x => x.ExportToExcel(peopleDto)).Returns(excelContent);

            // Act
            var result = _personController.ExportExcel();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FileResult>());
            var fileResult = (FileResult)result;
            Assert.Multiple(() =>
            {
                Assert.That(fileResult.ContentType, Is.EqualTo("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
                Assert.That(fileResult.FileDownloadName, Is.EqualTo("People.xlsx"));
            });
        }
    }

}
