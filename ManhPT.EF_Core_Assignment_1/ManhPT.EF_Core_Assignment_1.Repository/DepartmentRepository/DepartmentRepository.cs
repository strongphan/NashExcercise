using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository.BaseRepository;

namespace ManhPT.EF_Core_Assignment_1.Repository.DepartmentRepository
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(BusinessContext dbContext) : base(dbContext)
        {
        }
    }
}
