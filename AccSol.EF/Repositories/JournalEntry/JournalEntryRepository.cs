using AccSol.EF.Data;
using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public class JournalEntryRepository : RepositoryBase<Journal>, IJournalEntryRepository
    {
        public JournalEntryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Journal> GetAll(bool trackChanges) =>
        FindAll(trackChanges)
        .ToList();
        public Journal? Get(int? id, bool trackChanges) =>
        FindByCondition(c => c.ID == id, trackChanges)
        .FirstOrDefault();

        public void CreateJournalEntry(Journal journalEntry) => Create(journalEntry);
        public void UpdateJournalEntry(Journal journalEntry) => Update(journalEntry);
        public void DeleteJournalEntry(Journal journalEntry) => Delete(journalEntry);
    }
}