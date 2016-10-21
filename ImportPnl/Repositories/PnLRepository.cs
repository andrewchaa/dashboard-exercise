using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dashboard.App.ImportPnl.Domain.Models;

namespace Dashboard.App.ImportPnl.Repositories
{
    public class PnLRepository : IPnLRepository
    {
        private readonly IConfig _config;

        public PnLRepository(IConfig config)
        {
            _config = config;
        }

        public async Task<PnL> Add(PnL pnl)
        {
            var connectionStr = _config.GetConnectionString("Dashboard");
            using (var connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                var id = await connection.ExecuteAsync(
                    "INSERT INTO PnL (Date, Strategy, Amount) VALUES (@Date, @Strategy, @Amount)",
                    new { pnl.Date, pnl.Strategy, pnl.Amount });


                return new PnL {PnLId = id, Date = pnl.Date, Strategy = pnl.Strategy, Amount = pnl.Amount};
            }
        }
    }
}
