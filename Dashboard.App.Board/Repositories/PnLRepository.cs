﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Dashboard.App.Board.Domain.Contracts;
using Dashboard.App.Board.Domain.Models;
using Dashboard.App.Board.Helpers;

namespace Dashboard.App.Board.Repositories
{
    public class PnLRepository : IPnLRepository
    {
        private readonly IConfig _config;

        public PnLRepository(IConfig config)
        {
            _config = config;
        }

        public async Task<IEnumerable<PnL>> List()
        {
            var connectionStr = _config.GetConnectionString("Dashboard");
            using (var connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                var pnLs = await connection.QueryAsync<PnL>("select * from PnLs");

                return pnLs;
            }
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

            return await ExecuteQueryAsync(query, new { byDate });
        }

        private async Task<IEnumerable<PnLByRegion>> ExecuteQueryAsync(string query, object param = null)
        {
            var connectionStr = _config.GetConnectionString("Dashboard");
            using (var connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                var pnLs = await connection.QueryAsync<PnLByRegion>(query, param);

                return pnLs;
            }
        }
    }
}