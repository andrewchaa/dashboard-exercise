using System;

namespace Dashboard.Api.DataStore.Domain.Models
{
    public class PnLCapital
    {
        public DateTime Date { get; set; }
        public decimal PnL { get; set; }
        public string Region { get; set; }
        public int Strategy { get; set; }
        public decimal Capital { get; set; }
    }
}