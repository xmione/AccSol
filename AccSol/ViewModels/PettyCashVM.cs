using AccSol.EF.Models;
using AccSol.EF.Services;
using System.ComponentModel.DataAnnotations;

namespace AccSol.ViewModels
{
    public class PettyCashVM : PettyCash, IValidatableObject
    {
        public string? ClientName { get; set; }
        public string? ProjectName { get; set; }
        private IQueryable<PettyCash> _pettyCashQList;
        
        public PettyCashVM()
        {
            
        }
        public PettyCashVM(IQueryable<PettyCash> pettyCashQList)
        {
            _pettyCashQList = pettyCashQList;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Implement your custom validation logic here
            if (AlreadyExists(PCFNo))
            {
                yield return new ValidationResult("PCFNo already exists.", new[] { nameof(PCFNo) });
            }
        }

        private bool AlreadyExists(string pcfNo)
        {
            bool alreadyExists = false;

            if (pcfNo != null)
            {
                var foundItem = _pettyCashQList.FirstOrDefault(p => p.PCFNo == pcfNo);
                alreadyExists = foundItem != null;
            }

            return alreadyExists;
        }
    }
}
