using AccSol.EF.Data;
using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public class PettyCashRepository : RepositoryBase<PettyCash>, IPettyCashRepository
    {
        public PettyCashRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<PettyCash> GetAll(bool trackChanges) =>
        FindAll(trackChanges)
        .ToList();
        public PettyCash? Get(int? id, bool trackChanges) =>
        FindByCondition(c => c.ID == id, trackChanges)
        .FirstOrDefault();

        public void CreatePettyCash(PettyCash pettyCash) => Create(pettyCash);
        public void UpdatePettyCash(PettyCash pettyCash) => Update(pettyCash);
        public void DeletePettyCash(PettyCash pettyCash) => Delete(pettyCash);
    }
}