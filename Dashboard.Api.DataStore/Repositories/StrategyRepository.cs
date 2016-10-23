using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Domain.Models;
using Dashboard.Api.DataStore.Helpers;

namespace Dashboard.Api.DataStore.Repositories
{
    public class StrategyRepository : IStrategyRepository
    {
        private readonly IConfig _config;

        public StrategyRepository(IConfig config)
        {
            _config = config;
        }

        public async Task<IEnumerable<Strategy>> ListBy(string region)
        {
            var query =
                " select * from Strategies " +
                "  where Region = @region "
                ;

            return await Query.ExecuteAsync<Strategy>(
                _config.GetConnectionString("Dashboard"),
                query, new { region} );
        }
    }
}