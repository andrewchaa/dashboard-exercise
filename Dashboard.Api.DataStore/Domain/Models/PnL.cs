using System;

namespace Dashboard.Api.DataStore.Domain.Models
{
    public class PnL
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Region { get; set; }
        public string Strategy { get; set; }

    }
}