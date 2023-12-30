using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public interface IPettyCashRepository
    {
        IEnumerable<PettyCash> GetAll(bool trackChanges);
        PettyCash? Get(int? id, bool trackChanges);
        void CreatePettyCash(PettyCash pettyCash);
        void UpdatePettyCash(PettyCash pettyCash);
        void DeletePettyCash(PettyCash pettyCash);
    }
}
