using Asp.net_Core_Fundamentals.Model;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Fundamentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        [HttpPost("login")]
        public void PostAnything(int id, [FromBody] LoginRequestDto dto)
        {
            return;
        }
    }
}
