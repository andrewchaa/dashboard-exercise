using System.Collections.Generic;

namespace Dashboard.Api.DataStore.Models
{
    public class DataViewModel
    {
        public IEnumerable<string> labels { get; set; }
        public IEnumerable<IEnumerable<decimal>> series { get; set; }
    }
}