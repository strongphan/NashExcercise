using System.ComponentModel.DataAnnotations;

namespace ManhPT.EF_Core_Assignment_1.Service.DTOs.ProjectDto
{
    public class ProjectCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
