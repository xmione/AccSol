using AccSol.EF.Models;

namespace AccSol.ViewModels
{
    public class PettyCashVM : PettyCash
    {
        public string? ClientName { get; set; }
        public string? ProjectName { get; set; }
    }
}
