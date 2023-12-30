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
        public Coa? Get(int? id, bool trackChanges) =>
        FindByCondition(c => c.ID == id, trackChanges)
        .FirstOrDefault();

        public void CreateCoa(Coa coa) => Create(coa);
        public void UpdateCoa(Coa coa) => Update(coa);
        public void DeleteCoa(Coa coa) => Delete(coa);
    }
}