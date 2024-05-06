using Microsoft.AspNetCore.Mvc;
using MVCAssignment.BusinessLogic;

namespace MVCAssignment.WebApp.Controllers
{

    public class BaseController : Controller
    {
        private readonly IPersonBusinessLogic _businessLogic;

        public BaseController(IPersonBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }
    }
}
