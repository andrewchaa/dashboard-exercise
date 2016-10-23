using System;

namespace Dashboard.Api.DataStore.Domain.Models
{
    public class PnLDailyReturn
    {
        public DateTime Date { set; get; }
        public decimal PnL { get; set; }
        public decimal Capital { get; set; }
        public decimal DailyReturn { get; set; }
        public string Strategy { get; set; }
    }
}