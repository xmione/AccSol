﻿namespace AccSol.EF.Models
{
    public class Journal 
    {
        public int ID { get; set; }
        public int? PettyCashId { get; set; }
        public int? CoaId { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
    }
}
