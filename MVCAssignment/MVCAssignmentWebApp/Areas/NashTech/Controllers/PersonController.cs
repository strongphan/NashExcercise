using Microsoft.AspNetCore.Mvc;
using MVCAssignment.BusinessLogic;
using MVCAssignment.Model.Enum;
using MVCAssignment.Repository.DTOs;
using MVCAssignment.WebApp.Controllers;
using MVCAssignment.WebApp.NormalSevice;

namespace MVC_.NET_Core_Assignment_1.Areas.NashTech.Controllers
{
    [Area("NashTech")]

    public class PersonController : BaseController
    {
        private readonly IPersonBusinessLogic _businessLogic;

        public PersonController(IPersonBusinessLogic businessLogic) : base(businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public IActionResult Index()
        {
            var model = _businessLogic.GetPeople(new FilterPersonDto());

            return View(model);
        }

        public IActionResult GetMales()
        {
            var filter = new FilterPersonDto()
            {
                Gender = Gender.Male,
            };
            var model = _businessLogic.GetPeople(filter);
            return View("Index", model);
        }
        public IActionResult Get2000()
        {
            var filter = new FilterPersonDto()
            {
                Year = 2000,
            };
            var model = _businessLogic.GetPeople(filter);
            return View("Index", model);
        }
        public IActionResult GetBefore2000()
        {
            var filter = new FilterPersonDto()
            {
                BeforeYear = 2000,
            };
            var model = _businessLogic.GetPeople(filter);
            return View("Index", model);
        }
        public IActionResult GetAfter2000()
        {
            var filter = new FilterPersonDto()
            {
                AfterYear = 2000,
            };
            var model = _businessLogic.GetPeople(filter);
            return View("Index", model);
        }

        public IActionResult GetOldest()
        {
            var person = _businessLogic.GetOldestPerson();
            return View(person);
        }

        public IActionResult GetFullName()
        {
            var fullName = _businessLogic.GetFulName();
            return View("FullNameDisplay", fullName);
        }

        public IActionResult ExportExcel()
        {
            var model = _businessLogic.GetPeople(new FilterPersonDto());
            var excelService = new ExcelService();
            byte[] fileContent = excelService.ExportToExcel(model);
            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "People.xlsx");
        }
    }
}
