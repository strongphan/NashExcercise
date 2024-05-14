using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository.BaseRepository;

namespace ManhPT.EF_Core_Assignment_1.Repository.ProjectEmployeeRepository
{
    public class ProjectEmployeeRepository : BaseRepository<ProjectEmployee>, IProjectEmployeeRepository
    {
        public ProjectEmployeeRepository(BusinessContext dbContext) : base(dbContext)
        {
        }
    }

}
