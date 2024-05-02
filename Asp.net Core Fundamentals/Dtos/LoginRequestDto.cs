using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Fundamentals.Model
{
    public class LoginRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
