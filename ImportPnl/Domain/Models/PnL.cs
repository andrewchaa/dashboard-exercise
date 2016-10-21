using System;

namespace Dashboard.App.ImportPnl.Domain.Models
{
    public class PnL
    {
        public DateTime Date { get; set; }
        public int Strategy { get; set; }
        public decimal Amount { get; set; }
        public int PnLId { get; set; }
    }
}