using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.App.Board.Domain.Contracts;
using Dashboard.App.Board.Domain.Models;
using Dashboard.App.Board.Helpers;
using Dashboard.App.Board.Models;
using RestSharp;

namespace Dashboard.App.Board.Domain.Services
{
    public class DataApi : IDataApi
    {
        private readonly IConfig _config;
        private readonly RestClient _client;

        public DataApi(IConfig config)
        {
            _config = config;
            _client = new RestClient(_config.AppSettings("DataStoreEndpoint"));
        }

        public async Task<DataViewModel> ListCumulativePnLs(DateTime byDate)
        {
            var request = new RestRequest("api/pnls/{date}");
            request.AddParameter("date", byDate.ToString("yyyy-MM-dd"));

            var response = await _client.ExecuteGetTaskAsync<DataViewModel>(request);
            return response.Data;
        }

        public async Task<DataViewModel> ListCapitals()
        {
            var request = new RestRequest("api/capitals");
            var response = await _client.ExecuteGetTaskAsync<DataViewModel>(request);

            return response.Data;
        }

        public async Task<DataViewModel> ListCumulativeReturns(string region, DateTime byDate)
        {
            var request = new RestRequest("api/dailyreturns/{region}/{date}");
            request.AddParameter("region", region);
            request.AddParameter("date", byDate.ToString("yyyy-MM-dd"));

            var response = await _client.ExecuteGetTaskAsync<DataViewModel>(request);

            return response.Data;
        }
    }
}