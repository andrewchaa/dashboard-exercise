using System;

namespace Dashboard.Api.DataStore.Domain.Models
{
    public class Capital
    {
        public DateTime Date { get; set; }
        public int Strategy { get; set; }
        public decimal Amount { get; set; }
        public int CapitalId { get; set; }
        public string Region { get; set; }
    }
}