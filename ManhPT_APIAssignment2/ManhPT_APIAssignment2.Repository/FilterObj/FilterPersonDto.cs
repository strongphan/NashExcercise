using ManhPT_APIAssignment2.Model.Enum;

namespace ManhPT_APIAssignment2.Repository
{
    public class FilterPersonDto
    {
        public string Name { get; set; } = string.Empty;
        public Gender? Gender { get; set; }
        public string BirthPlace { get; set; } = string.Empty;
    }
}
