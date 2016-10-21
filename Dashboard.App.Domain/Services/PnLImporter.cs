using System;
using System.Collections.Generic;
using System.Globalization;
using Dashboard.App.Domain.Models;
using Dashboard.App.Domain.Repositories;

namespace Dashboard.App.Domain.Services
{
    public class PnLImporter : IImportPnL
    {
        private readonly IPnLRepository _repository;

        public PnLImporter(IPnLRepository repository)
        {
            _repository = repository;
        }

        public void Import(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var columns = line.Split(',');
                var date = DateTime.ParseExact(columns[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                for (int i = 1; i < 16; i++)
                {
                    var pnl = new PnL { Amount = decimal.Parse(columns[i]), Strategy = i, Date = date };
                    _repository.Add(pnl);
                }
            }

        }
    }
}
