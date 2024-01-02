using AccSol.EF.Data;
using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public class JournalEntryRepository : RepositoryBase<JournalEntry>, IJournalEntryRepository
    {
        public JournalEntryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<JournalEntry> GetAll(bool trackChanges) =>
        FindAll(trackChanges)
        .ToList();
        public JournalEntry? Get(int? id, bool trackChanges) =>
        FindByCondition(c => c.ID == id, trackChanges)
        .FirstOrDefault();

        public void CreateJournalEntry(JournalEntry journalEntry) => Create(journalEntry);
        public void UpdateJournalEntry(JournalEntry journalEntry) => Update(journalEntry);
        public void DeleteJournalEntry(JournalEntry journalEntry) => Delete(journalEntry);
    }
}