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

        public DataCruncher(IStrategyRepository strategyRepository, IPnLRepository pnLRepository)
        {
            _strategyRepository = strategyRepository;
            _pnLRepository = pnLRepository;
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
    }
}