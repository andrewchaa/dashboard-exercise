using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace Dashboard.Api.DataStore.Helpers
{
    public class Query
    {
        public static async Task<IEnumerable<T>> ExecuteAsync<T>(string connString, string query, object param = null)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var pnLs = await connection.QueryAsync<T>(query, param);

                return (IEnumerable<T>)pnLs;
            }
        }

    }
}