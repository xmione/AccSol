namespace AccSol.EF.Models
{
    public class PettyCash
    {
        public int ID { get; set; }
        public string? PCFNo { get; set; }
        public DateTime? Date { get; set; }
        public string? Payee { get; set; }
        public string? Particulars { get; set; }
        public int? ClientId { get; set; }
        public int? ProjectCodeId { get; set; }
        public decimal? Amount { get; set; }
    }
}
