using AccSol.Components.Pages.Client;
using AccSol.Components.Pages.ProjectCode;
using AccSol.EF.Models;
using System.ComponentModel.DataAnnotations;

namespace AccSol.ViewModels
{
    public class JournalVM : Journal, IValidatableObject
    {
        public string? AccountName { get; set; }
        private List<JournalVM> _journalVMEntryList = new List<JournalVM>(); // Initialize the list
        private List<Coa> _coas = new List<Coa>(); // Initialize the list
        public bool IsEditing { get; set; } // Boolean property to indicate editing mode

        public JournalVM(Journal journal, List<Coa> coas)
        {
            _coas = coas;

            ID = journal.ID;
            PettyCashId = journal.PettyCashId;
            Debit = journal.Debit;
            Credit = journal.Credit;

            int coaId = journal.CoaId ?? _coas[0].ID;
            CoaId = coaId;

            AccountName = GetAccountName(coaId);
        }
        public JournalVM(JournalVM journalVM, List<Coa> coas)
        {
            _coas = coas;

            ID = journalVM.ID;
            PettyCashId = journalVM.PettyCashId;
            Debit = journalVM.Debit;
            Credit = journalVM.Credit;

            int coaId = journalVM.CoaId ?? _coas[0].ID;
            CoaId = coaId;

            AccountName = journalVM.CoaId != null? journalVM.AccountName : GetAccountName(coaId);
            
        }
        public JournalVM()
        {
        }
        public void SetJournalEntryVMList(List<JournalVM> journalVMEntryList)
        {
            _journalVMEntryList = journalVMEntryList;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Ensure _journalVMEntryList is set before calling Validate
            if (_journalVMEntryList == null)
            {
                // Log or handle the situation where _journalVMEntryList is not set
                yield break; // Exit the validation early
            }

            // Implement your custom validation logic here
            //if (!IsEditing && AlreadyExists(AccountName, ID)) // Check existence only in editing mode
            //{
            //    yield return new ValidationResult("AccountName already exists.", new[] { nameof(AccountName) });
            //}
        }

        private bool AlreadyExists(string accountName, int currentItemId)
        {
            bool alreadyExists = false;

            if (accountName != null)
            {
                // Exclude the current item from the search
                var foundItem = _journalVMEntryList.FirstOrDefault(p => p.AccountName == accountName && p.ID != currentItemId);
                alreadyExists = foundItem != null;
            }

            return alreadyExists;
        }

        private string GetAccountName(int coaId)
        {
            string name = string.Empty;

            var foundName = _coas?.FirstOrDefault(c => c.ID == coaId)?.AccountName;
            name = foundName ?? string.Empty;
            
            return name;
        }
    }
}
