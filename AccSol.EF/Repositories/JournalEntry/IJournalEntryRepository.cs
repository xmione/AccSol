using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public interface IJournalEntryRepository
    {
        IEnumerable<Journal> GetAll(bool trackChanges);
        Journal? Get(int? id, bool trackChanges);
        void CreateJournalEntry(Journal journalEntry);
        void UpdateJournalEntry(Journal journalEntry);
        void DeleteJournalEntry(Journal journalEntry);
    }
}
