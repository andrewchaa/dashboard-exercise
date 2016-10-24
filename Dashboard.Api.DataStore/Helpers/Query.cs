using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using NLog;

namespace Dashboard.Api.DataStore.Helpers
{
    public class Query
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static async Task<IEnumerable<T>> ExecuteAsync<T>(string connString, string query, object param = null)
        {
            Logger.Info("Executing a query: {0}", query);

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var pnLs = await connection.QueryAsync<T>(query, param);

                return pnLs;
            }
        }

    }
}