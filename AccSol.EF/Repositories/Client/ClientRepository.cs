using AccSol.EF.Data;
using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Client> GetAll(bool trackChanges) =>
        FindAll(trackChanges)
        .ToList();
        public Client? Get(int? id, bool trackChanges) =>
        FindByCondition(c => c.ID == id, trackChanges)
        .FirstOrDefault();

        public void CreateClient(Client client) => Create(client);
        public void UpdateClient(Client client) => Update(client);
        public void DeleteClient(Client client) => Delete(client);
    }
}