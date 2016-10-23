using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.App.Board.Domain.Contracts;
using Dashboard.App.Board.Helpers;
using Dashboard.App.Board.Models;

namespace Dashboard.App.Board.Domain.Services
{
    public class CumulativePnLStore : ICumulativePnLStore
    {
        private readonly IPnLRepository _repository;

        public CumulativePnLStore(IPnLRepository repository)
        {
            _repository = repository;
        }

        public async Task<DataViewModel> ListCumulativePnL(DateTime byDate)
        {
            var pnls = await _repository.ListByRegion(byDate);

            var labels = pnls.Where(p => p.Region == "AP").Select(p => p.Date.ToShortDateString());
            var aps = pnls.Where(p => p.Region == "AP").Select(p => p.Amount).CumulativeSum().ToList();
            var eus = pnls.Where(p => p.Region == "EU").Select(p => p.Amount).CumulativeSum().ToList();
            var uses = pnls.Where(p => p.Region == "US").Select(p => p.Amount).CumulativeSum().ToList();

            return new DataViewModel
            {
                Labels = labels,
                Data = new List<List<decimal>>
                {
                    aps, eus, uses
                }
            };
        }
    }
}