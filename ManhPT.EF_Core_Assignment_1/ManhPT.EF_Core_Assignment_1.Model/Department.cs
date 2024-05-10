using System.ComponentModel.DataAnnotations;

namespace ManhPT.EF_Core_Assignment_1.Model
{
    public class Department : IHaskey
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

        public Guid GetKey()
        {
            return Id;
        }
    }
}
