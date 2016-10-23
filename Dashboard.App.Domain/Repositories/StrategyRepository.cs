using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Dashboard.App.Domain.Contracts;
using Dashboard.App.Domain.Models;

namespace Dashboard.App.Domain.Repositories
{
    public class StrategyRepository : IStrategyRepository
    {
        private readonly IConfig _config;

        public StrategyRepository(IConfig config)
        {
            _config = config;
        }

        public async Task<Strategy> Add(Strategy strategy)
        {
            var connectionStr = _config.GetConnectionString("Dashboard");
            using (var connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                await connection.ExecuteAsync(
                    "INSERT INTO Strategies (StrategyId, Region) VALUES (@StrategyId, @Region)",
                    new { strategy.StrategyId, strategy.Region });


                return strategy;
            }
        }
    }
}
