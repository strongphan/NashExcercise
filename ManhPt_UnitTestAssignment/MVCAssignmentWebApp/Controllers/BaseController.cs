using Microsoft.AspNetCore.Mvc;
using MVCAssignment.Service;

namespace MVCAssignment.WebApp.Controllers
{

    public class BaseController : Controller
    {
        private readonly IPersonService _service;

        public BaseController(IPersonService service)
        {
            _service = service;
        }
    }
}
