using ManhPT_APIAssignment2.Model.Enum;

namespace ManhPT_APIAssignment2.API.DTOs
{
    public class PersonCreateDto
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public Gender Gender { get; set; }


        public DateTime DOB { get; set; }

        public string BirthPlace { get; set; }
    }
}
