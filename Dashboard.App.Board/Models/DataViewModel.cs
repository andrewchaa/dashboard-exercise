using System.Collections.Generic;

namespace Dashboard.App.Board.Models
{
    public class DataViewModel
    {
        public List<string> labels { get; set; }
        public List<List<decimal>> series { get; set; }
    }
}