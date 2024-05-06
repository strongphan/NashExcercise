using Asp.net_Core_Fundamentals.Model;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Fundamentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        /// <summary>
        /// Simple api to test log 
        /// </summary>
        /// <param name="id">example query string</param>
        /// <param name="dto">example body</param>
        [HttpPost("login")]
        public void PostAnything(int id, [FromBody] LoginRequestDto dto)
        {
            return;
        }
    }
}
