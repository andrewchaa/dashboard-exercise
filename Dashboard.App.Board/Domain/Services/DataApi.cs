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

        public DataApi(IConfig config)
        {
            _config = config;
        }

        public async Task<DataViewModel> ListCumulativePnLs(DateTime byDate)
        {
            var client = new RestClient(_config.AppSettings("DataStoreEndpoint"));

            var request = new RestRequest("api/pnls/{date}");
            request.AddParameter("date", byDate.ToString("yyyy-MM-dd"));

            var response = await client.ExecuteGetTaskAsync<DataViewModel>(request);
            return response.Data;
        }

        public async Task<DataViewModel> ListCapitals()
        {
            var client = new RestClient(_config.AppSettings("DataStoreEndpoint"));

            var request = new RestRequest("api/capitals");
            var response = await client.ExecuteGetTaskAsync<DataViewModel>(request);

            return response.Data;
        }
    }
}