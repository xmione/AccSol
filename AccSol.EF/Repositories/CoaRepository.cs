using AccSol.EF.Data;
using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public class CoaRepository : RepositoryBase<Coa>, ICoaRepository
    {
        public CoaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Coa> GetAll(bool trackChanges) =>
        FindAll(trackChanges)
        .ToList();
        public Coa? Get(Coa coa, bool trackChanges) =>
        FindByCondition(c => c.ID == coa.ID, trackChanges)
        .FirstOrDefault();
    }
}