using AccSol.EF.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace AccSol.ViewModels
{
    public class PettyCashVM : PettyCash, IValidatableObject
    {
        public string? ClientName { get; set; }
        public string? ProjectName { get; set; }
        private List<PettyCash> _pettyCashList = new List<PettyCash>(); // Initialize the list
        private List<Client> _clients = new List<Client>(); // Initialize the list
        private List<ProjectCode> _projectCodes = new List<ProjectCode>(); // Initialize the list

        public bool IsEditing { get; set; } // Boolean property to indicate editing mode

        public PettyCashVM()
        {
        }
        public PettyCashVM(PettyCash pettyCash, List<Client> clientList, List<ProjectCode> projectCodeList)
        {
            _clients = clientList;
            _projectCodes = projectCodeList;

            ID = pettyCash.ID;
            PCFNo = pettyCash.PCFNo;
            Date = pettyCash.Date;
            Payee = pettyCash.Payee;
            Particulars = pettyCash.Particulars;
            Amount = pettyCash.Amount;
            
            int clientId = pettyCash.ClientId ?? _clients[0].ID;
            int projectCodeId = pettyCash.ProjectCodeId ?? _projectCodes[0].ID;
            ClientId = clientId;
            ProjectCodeId = projectCodeId;

            ClientName = GetClientName(clientId);
            ProjectName = GetProjectName(projectCodeId);
        }
        public PettyCashVM(PettyCashVM pettyCashVM, List<Client> clientList, List<ProjectCode> projectCodeList)
        {
            
            _clients = clientList;
            _projectCodes = projectCodeList;

            ID = pettyCashVM.ID;
            PCFNo = pettyCashVM.PCFNo;
            Date = pettyCashVM.Date;
            Payee = pettyCashVM.Payee;
            Particulars = pettyCashVM.Particulars;
            Amount = pettyCashVM.Amount;

            int clientId = pettyCashVM.ClientId ?? _clients[0].ID;
            int projectCodeId = pettyCashVM.ProjectCodeId ?? _projectCodes[0].ID;
            ClientId = clientId;
            ProjectCodeId = projectCodeId;

            ClientName = pettyCashVM.ClientId != null? pettyCashVM.ClientName : GetClientName(clientId);
            ProjectName = pettyCashVM.ProjectCodeId != null? pettyCashVM.ProjectName : GetProjectName(projectCodeId);
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

        private string GetClientName(int id)
        {
            string name = string.Empty;

            name = _clients?.FirstOrDefault(c => c.ID == id)?.Name;

            return name;
        }

        private string GetProjectName(int id)
        {
            string name = string.Empty;

            name = _projectCodes?.FirstOrDefault(c => c.ID == id)?.Description;

            return name;
        }

    }
}
