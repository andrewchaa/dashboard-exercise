using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.App.Board.Domain.Contracts;
using Dashboard.App.Board.Domain.Models;
using RestSharp;

namespace Dashboard.App.Board.Repositories
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
            var client = new RestClient(_config.AppSettings("DataStoreEndpoint"));

            var request = new RestRequest("api/pnls/{date}");
            request.AddParameter("date", byDate.ToString("yyyy-MM-dd"));

            var response = await client.ExecuteGetTaskAsync<List<PnLByRegion>>(request);

            return response.Data;
        }
    }
}