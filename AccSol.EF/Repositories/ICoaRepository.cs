using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public interface ICoaRepository
    {
        IEnumerable<Coa> GetAll(bool trackChanges);
        Coa? Get(int? id, bool trackChanges);
        void Create(Coa coa);
        void Update(Coa coa);
        void Delete(Coa coa) => Delete(coa);
    }
}
