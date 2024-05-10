namespace ManhPT.EF_Core_Assignment_1.Model
{
    public class ProjectEmployee : IHaskey
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public bool Enable { get; set; }
        public Project Project { get; set; }
        public Employee Employee { get; set; }

        public Guid GetKey()
        {
            return Id;
        }
    }
}
