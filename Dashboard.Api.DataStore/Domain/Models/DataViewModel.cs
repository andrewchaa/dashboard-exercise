using System.Collections.Generic;

namespace Dashboard.App.Board.Models
{
    public class DataViewModel
    {
        public IEnumerable<string> Labels { get; set; }
        public IEnumerable<IEnumerable<decimal>> Data { get; set; }
    }
}