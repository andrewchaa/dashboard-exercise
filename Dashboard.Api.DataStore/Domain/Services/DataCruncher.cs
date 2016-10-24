using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Domain.Models;

namespace Dashboard.Api.DataStore.Domain.Services
{
    public class DataCruncher : ICrunchData
    {
        private readonly IStrategyRepository _strategyRepository;
        private readonly IPnLRepository _pnLRepository;
        private readonly ICapitalRepository _capitalRepository;

        public DataCruncher(IStrategyRepository strategyRepository, IPnLRepository pnLRepository,
            ICapitalRepository capitalRepository)
        {
            _strategyRepository = strategyRepository;
            _pnLRepository = pnLRepository;
            _capitalRepository = capitalRepository;
        }


        public async Task<IEnumerable<IEnumerable<PnLDailyReturn>>> ListAccumulativeReturn(
            string region, DateTime byDate)
        {
            var strategies = await _strategyRepository.ListBy(region);
            var pnlCapitals = new List<IEnumerable<PnLDailyReturn>>();

            foreach (var strategy in strategies)
            {
                var pnlCapital = await _pnLRepository.ListBy(strategy.StrategyId, byDate);
                var dailyReturns = pnlCapital.Select(p => new PnLDailyReturn {
                    Strategy = p.Strategy,
                    Date = p.Date,
                    PnL = p.PnL,
                    Capital = p.Capital,
                    DailyReturn = Math.Round(p.PnL / p.Capital * 100m, 2)
                });
                
                pnlCapitals.Add(dailyReturns);
            }

            return pnlCapitals;
        }

        public async Task<IEnumerable<IEnumerable<Capital>>> ListMonthlyCapitals()
        {
            var capitals1 = _capitalRepository.ListBy(1);
            var capitals4 = _capitalRepository.ListBy(4);
            var capitals8 = _capitalRepository.ListBy(8);
            var capitals9 = _capitalRepository.ListBy(9);
            var capitals14 = _capitalRepository.ListBy(14);

            var capitalsList = await Task.WhenAll(capitals1, capitals4, capitals8, capitals9,
                capitals14);

            return capitalsList;
        }
    }
}