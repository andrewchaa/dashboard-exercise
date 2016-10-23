using System.Collections.Generic;

namespace Dashboard.App.Domain.Contracts
{
    public interface IImportDataCsv
    {
        void Import(IEnumerable<string> lines);
    }
}