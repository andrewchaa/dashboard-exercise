using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Domain.Models;
using Dashboard.Api.DataStore.Helpers;

namespace Dashboard.Api.DataStore.Repositories
{
    public class CapitalRepository : ICapitalRepository
    {
        private readonly IConfig _config;

        public CapitalRepository(IConfig config)
        {
            _config = config;
        }

        public async Task<IEnumerable<Capital>> ListBy(int strategyId)
        {
            var query =
                " select * from Capitals " +
                "  where Strategy = @strategyId " +
                "  order by Date "
                ;

            return await Query.ExecuteAsync<Capital>(
                _config.GetConnectionString("Dashboard"),
                query, new { strategyId} );

        }

        public async Task<IEnumerable<Capital>> ListBy(string region)
        {
            var query =
                "  select c.Date, c.Strategy, c.Amount, s.Region " +
                "   from Capitals c JOIN Strategies s " +
                "     on c.Strategy = s.StrategyId " +
                "  where s.Region = @region " +
                "  order by c.Strategy, c.Date "
                ;

            return await Query.ExecuteAsync<Capital>(
                _config.GetConnectionString("Dashboard"),
                query, new { region} );

        }
    }
}