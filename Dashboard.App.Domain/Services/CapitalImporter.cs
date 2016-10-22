using System;
using System.Collections.Generic;
using System.Globalization;
using Dashboard.App.Domain.Models;
using Dashboard.App.Domain.Repositories;

namespace Dashboard.App.Domain.Services
{
    public class CapitalImporter : IImportDataCsv
    {
        private readonly ICapitalRepository _repository;

        public CapitalImporter(ICapitalRepository repository)
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
                    var capital = new Capital { Amount = decimal.Parse(columns[i]), Strategy = i, Date = date };
                    _repository.Add(capital);
                }
            }

        }
    }
}
