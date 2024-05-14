using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository.BaseRepository;

namespace ManhPT.EF_Core_Assignment_1.Repository.ProjectRepository
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(BusinessContext dbContext) : base(dbContext)
        {
        }
    }

}
