using MVCAssignment.Model.Enum;

namespace MVCAssignment.Repository.DTOs
{
    public class FilterPersonDto
    {
        public Gender? Gender { get; set; }
        public int? Year { get; set; }
        public int? BeforeYear { get; set; }
        public int? AfterYear { get; set; }
        public bool? IsGraduated { get; set; }
    }
}
