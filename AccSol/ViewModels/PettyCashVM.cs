using AccSol.EF.Models;
using AccSol.EF.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AccSol.ViewModels
{
    public class PettyCashVM : PettyCash, IValidatableObject
    {
        public string? ClientName { get; set; }
        public string? ProjectName { get; set; }
        private List<PettyCash> _pettyCashList = new List<PettyCash>(); // Initialize the list
        public bool IsEditing { get; set; } // Boolean property to indicate editing mode

        public PettyCashVM()
        {
        }

        public void SetPettyCashList(List<PettyCash> pettyCashList)
        {
            _pettyCashList = pettyCashList;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Ensure _pettyCashList is set before calling Validate
            if (_pettyCashList == null)
            {
                // Log or handle the situation where _pettyCashList is not set
                yield break; // Exit the validation early
            }

            // Implement your custom validation logic here
            if (!IsEditing && AlreadyExists(PCFNo, ID)) // Check existence only in editing mode
            {
                yield return new ValidationResult("PCFNo already exists.", new[] { nameof(PCFNo) });
            }
        }

        private bool AlreadyExists(string pcfNo, int currentItemId)
        {
            bool alreadyExists = false;

            if (pcfNo != null)
            {
                // Exclude the current item from the search
                var foundItem = _pettyCashList.FirstOrDefault(p => p.PCFNo == pcfNo && p.ID != currentItemId);
                alreadyExists = foundItem != null;
            }

            return alreadyExists;
        }
    }
}
