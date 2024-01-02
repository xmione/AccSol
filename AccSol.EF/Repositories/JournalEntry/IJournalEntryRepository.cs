using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public interface IJournalEntryRepository
    {
        IEnumerable<JournalEntry> GetAll(bool trackChanges);
        JournalEntry? Get(int? id, bool trackChanges);
        void CreateJournalEntry(JournalEntry journalEntry);
        void UpdateJournalEntry(JournalEntry journalEntry);
        void DeleteJournalEntry(JournalEntry journalEntry);
    }
}
