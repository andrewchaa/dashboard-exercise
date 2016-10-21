using System.Collections.Generic;

namespace Dashboard.App.Domain.Services
{
    public interface IImportPnL
    {
        void Import(IEnumerable<string> lines);
    }
}