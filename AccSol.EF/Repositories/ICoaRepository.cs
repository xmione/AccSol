using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public interface ICoaRepository
    {
        IEnumerable<Coa> GetAll(bool trackChanges);
        Coa? Get(Coa coa, bool trackChanges);
    }
}
