using System.Collections.Generic;

namespace Dashboard.App.ImportPnl.Domain.Services
{
    public interface IImportPnL
    {
        void Import(IEnumerable<string> lines);
    }
}