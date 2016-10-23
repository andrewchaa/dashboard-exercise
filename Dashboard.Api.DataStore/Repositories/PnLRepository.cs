using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Domain.Models;
using Dashboard.Api.DataStore.Helpers;

namespace Dashboard.Api.DataStore.Repositories
{
    public class PnLRepository : IPnLRepository
    {
        private readonly IConfig _config;

        public PnLRepository(IConfig config)
        {
            _config = config;
        }


        public async Task<IEnumerable<PnLByRegion>> ListByRegion(DateTime byDate)
        {
            var query =
                "select s.Region, p.Date, SUM (p.Amount) as Amount " +
                "  from PnLs p join Strategies s " +
                "    on p.Strategy = s.StrategyId " +
                " where p.Date <= @byDate " +
                " group by p.Date, s.Region " +
                " order by s.Region, p.Date "
                ;

            return await Query.ExecuteAsync<PnLByRegion>(
                _config.GetConnectionString("Dashboard"),
                query, new { byDate }
                );
        }

        public async Task<IEnumerable<PnLCapital>> ListBy(int strategy, DateTime byDate)
        {
            var query =
                " select s.Region, p.Date, p.Amount as PnL, p.Strategy, ( " +
                "       select c.Amount as Capital from Capitals c " +
                "        where c.Strategy = p.Strategy " +
                "          and MONTH(c.Date) = MONTH(p.Date) " +
                "          and YEAR(c.Date) = YEAR(p.Date) " +
		        "       ) as Capital " +
                "  from PnLs p " +
                "  join Strategies s on p.Strategy = s.StrategyId " +
                "  where p.Strategy = @strategy " +
                "    and p.Date <= @byDate " +
                "  order by p.Date "
                ;

            return await Query.ExecuteAsync<PnLCapital>(
                _config.GetConnectionString("Dashboard"),
                query, new { strategy, byDate }
                );
        }

    }
}
