using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManhPT.EF_Core_Assignment_1.Model
{
    public class ProjectEmployee : IHaskey
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public Guid ProjectId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
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
