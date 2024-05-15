using Microsoft.AspNetCore.Mvc;
using MVCAssignment.Model.Enum;
using MVCAssignment.Repository.DTOs;
using MVCAssignment.Service;
using MVCAssignment.WebApp.Controllers;
using MVCAssignment.WebApp.NormalSevice;

namespace MVC_.NET_Core_Assignment_1.Areas.NashTech.Controllers
{
    [Area("NashTech")]

    public class PersonController : BaseController
    {
        private readonly IPersonService _service;
        private readonly IExcelService _excelService;

        public PersonController(IPersonService service, IExcelService excelService) : base(service)
        {
            _service = service;
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            var model = _service.GetPeople(new FilterPersonDto());

            return View(model);
        }
        public IActionResult Detail(Guid Id)
        {
            var person = _service.GetPersonById(Id);
            if (person == null)
            {
                return NotFound();
            }
            return View("Detail", person);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonDto dto)
        {

            if (ModelState.IsValid)
            {
                _ = _service.AddPerson(dto);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(Guid Id)
        {
            var person = _service.GetPersonById(Id);
            if (person == null)
            {
                return NotFound();
            }
            return View("Edit", person);
        }

        [HttpPost]
        public IActionResult Edit(PersonDto person)
        {

            if (ModelState.IsValid)
            {
                var result = _service.UpdatePerson(person);
                return RedirectToAction("Index");
            }
            return View("Edit", person);


        }
        public IActionResult Delete(Guid Id)
        {

            var person = _service.GetPersonById(Id);
            if (person == null)
            {
                return NotFound();
            }

            _service.DeletePerson(Id);
            return View("DeleteComplete", person.FirstName);

        }
        public IActionResult GetMales()
        {
            var filter = new FilterPersonDto()
            {
                Gender = Gender.Male,
            };
            var model = _service.GetPeople(filter);
            return View("Index", model);
        }
        public IActionResult Get2000()
        {
            var filter = new FilterPersonDto()
            {
                Year = 2000,
            };
            var model = _service.GetPeople(filter);
            return View("Index", model);
        }
        public IActionResult GetBefore2000()
        {
            var filter = new FilterPersonDto()
            {
                BeforeYear = 2000,
            };
            var model = _service.GetPeople(filter);
            return View("Index", model);
        }
        public IActionResult GetAfter2000()
        {
            var filter = new FilterPersonDto()
            {
                AfterYear = 2000,
            };
            var model = _service.GetPeople(filter);
            return View("Index", model);
        }

        public IActionResult GetOldest()
        {
            var person = _service.GetOldestPerson();
            return View("Detail", person);
        }

        public IActionResult GetFullName()
        {
            var fullName = _service.GetFulName();
            return View("FullNameDisplay", fullName);
        }

        public IActionResult ExportExcel()
        {
            var model = _service.GetPeople(new FilterPersonDto());
            byte[] fileContent = _excelService.ExportToExcel(model);
            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "People.xlsx");
        }
    }
}
