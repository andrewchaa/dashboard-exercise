using System.Collections.Generic;

namespace Dashboard.App.Domain.Services
{
    public interface IImportDataCsv
    {
        void Import(IEnumerable<string> lines);
    }
}