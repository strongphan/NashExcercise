namespace ManhPT_APIAssignment.API.Dtos
{
    public class ToDoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
