namespace AccSol.ViewModels
{
    public class JournalEntryViewModel
    {
        public int ID { get; set; }
        public int? PettyCashId { get; set; }
        public int? CoaId { get; set; }
        public string? AccountName { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
    }
}
