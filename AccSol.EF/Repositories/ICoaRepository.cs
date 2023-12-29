using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public interface ICoaRepository
    {
        IEnumerable<Coa> GetAll(bool trackChanges);
        Coa? Get(int? id, bool trackChanges);
        void CreateCoa(Coa coa);
        void UpdateCoa(Coa coa);
        void DeleteCoa(Coa coa);
    }
}
