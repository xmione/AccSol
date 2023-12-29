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

        public new void Create(Coa coa) => Create(coa);
         
        public new void Update(Coa coa) => Update(coa);
        public new void Delete(Coa coa) => Delete(coa);
    }
}