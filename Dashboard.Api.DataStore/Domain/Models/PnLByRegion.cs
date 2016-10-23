using System;

namespace Dashboard.Api.DataStore.Domain.Models
{
    public class PnLByRegion
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Region { get; set; }
    }
}