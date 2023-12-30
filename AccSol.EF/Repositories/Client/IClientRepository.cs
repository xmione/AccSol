using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll(bool trackChanges);
        Client? Get(int? id, bool trackChanges);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
    }
}
