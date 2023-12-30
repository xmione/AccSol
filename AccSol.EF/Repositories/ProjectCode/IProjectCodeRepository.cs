using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public interface IProjectCodeRepository
    {
        IEnumerable<ProjectCode> GetAll(bool trackChanges);
        ProjectCode? Get(int? id, bool trackChanges);
        void CreateProjectCode(ProjectCode projectCode);
        void UpdateProjectCode(ProjectCode projectCode);
        void DeleteProjectCode(ProjectCode projectCode);
    }
}
