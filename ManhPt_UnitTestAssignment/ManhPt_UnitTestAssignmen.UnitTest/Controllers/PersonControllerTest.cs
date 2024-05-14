using Microsoft.AspNetCore.Mvc;
using Moq;
using MVC_.NET_Core_Assignment_1.Areas.NashTech.Controllers;
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
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            //arrange
            var result = _personController.Create();

            Assert.IsInstanceOf<ViewResult>(result);
        }
        /*[Test]
        *//*public void Create_InvalidModelState_ReturnsView()
        {
            _personController.ModelState.AddModelError("FirstName", "FirstName is required");

            var person = new PersonDto { LastName = "as", PhoneNumber = "848635623" };

            var result = _personController.Create(person);

            var viewResult = Assert.IsInstanceOf<ViewResult>(result);
            var testPerson = Assert.IsType<PersonDto>(viewResult.Model);

            Assert.Equal(person.AccountNumber, testPerson.AccountNumber);
            Assert.Equal(person.Age, testPerson.Age);
        }*/
    }
}
