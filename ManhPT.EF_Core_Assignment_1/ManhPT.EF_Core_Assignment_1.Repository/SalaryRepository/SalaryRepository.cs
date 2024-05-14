using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository.BaseRepository;

namespace ManhPT.EF_Core_Assignment_1.Repository.SalaryRepository
{
    public class SalaryRepository : BaseRepository<Salary>, ISalaryRepository
    {
        public SalaryRepository(BusinessContext dbContext) : base(dbContext)
        {
        }
    }

}
