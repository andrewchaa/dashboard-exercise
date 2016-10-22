using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Dashboard.App.Domain.Models;

namespace Dashboard.App.Domain.Repositories
{
    public class CapitalRepository : ICapitalRepository
    {
        private readonly IConfig _config;

        public CapitalRepository(IConfig config)
        {
            _config = config;
        }

        public async Task<Capital> Add(Capital pnl)
        {
            var connectionStr = _config.GetConnectionString("Dashboard");
            using (var connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                var id = await connection.ExecuteAsync(
                    "INSERT INTO Capital (Date, Strategy, Amount) VALUES (@Date, @Strategy, @Amount)",
                    new { pnl.Date, pnl.Strategy, pnl.Amount });


                return new Capital {CapitalId = id, Date = pnl.Date, Strategy = pnl.Strategy, Amount = pnl.Amount};
            }
        }
    }
}
