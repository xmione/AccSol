using AccSol.EF.Data;
using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public class ProjectCodeRepository : RepositoryBase<ProjectCode>, IProjectCodeRepository
    {
        public ProjectCodeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ProjectCode> GetAll(bool trackChanges) =>
        FindAll(trackChanges)
        .ToList();
        public ProjectCode? Get(int? id, bool trackChanges) =>
        FindByCondition(c => c.ID == id, trackChanges)
        .FirstOrDefault();

        public void CreateProjectCode(ProjectCode projectCode) => Create(projectCode);
        public void UpdateProjectCode(ProjectCode projectCode) => Update(projectCode);
        public void DeleteProjectCode(ProjectCode projectCode) => Delete(projectCode);
    }
}