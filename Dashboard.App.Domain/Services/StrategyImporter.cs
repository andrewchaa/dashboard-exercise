using System.Collections.Generic;
using Dashboard.App.Domain.Contracts;
using Dashboard.App.Domain.Models;

namespace Dashboard.App.Domain.Services
{
    public class StrategyImporter : IImportDataCsv
    {
        private readonly IStrategyRepository _repository;

        public StrategyImporter(IStrategyRepository repository)
        {
            _repository = repository;
        }

        public void Import(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var columns = line.Split(',');
                var strategy = new Strategy
                {
                    StrategyId = int.Parse(columns[0].Replace("Strategy", string.Empty)),
                    Region = columns[1]
                };

                _repository.Add(strategy);
            }

        }
    }
}
