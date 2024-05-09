using System.Net;

namespace ManhPT_APIAssignment2.Model
{
    public class GeneralResponse
    {
        public bool Success { get; set; } = false;

        public HttpStatusCode StatusCode { get; set; }

        public GeneralValidationResult ValidationResult { get; set; } = new GeneralValidationResult();
    }
}
