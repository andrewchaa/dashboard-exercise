using System.Collections.Generic;

namespace Dashboard.App.Board.Models
{
    public class DataViewModel
    {
        public List<string> Labels { get; set; }
        public List<List<decimal>> Data { get; set; }
    }
}