using System;
using System.Threading.Tasks;
using Dashboard.App.Board.Domain.Contracts;
using Dashboard.App.Board.Models;
using NLog;
using RestSharp;

namespace Dashboard.App.Board.Domain.Services
{
    public class DataApi : IDataApi
    {
        private readonly IConfig _config;
        private readonly RestClient _client;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public DataApi(IConfig config)
        {
            _config = config;
            _client = new RestClient(_config.AppSettings("DataStoreEndpoint"));
        }

        public async Task<DataViewModel> ListCumulativePnLs(DateTime byDate)
        {
            Logger.Info("Calling cumulative pnls data endpoint ... by {0}", byDate);

            var request = new RestRequest("api/pnls/{date}");
            request.AddParameter("date", byDate.ToString("yyyy-MM-dd"));

            var response = await _client.ExecuteGetTaskAsync<DataViewModel>(request);
            return response.Data;
        }

        public async Task<DataViewModel> ListCapitals()
        {
            Logger.Info("Calling capitals data endpoint ...");

            var request = new RestRequest("api/capitals");
            var response = await _client.ExecuteGetTaskAsync<DataViewModel>(request);

            return response.Data;
        }

        public async Task<DataViewModel> ListCumulativeReturns(string region, DateTime byDate)
        {
            Logger.Info("Calling daily return data endpoint by {0} and {1}", region, byDate);

            var request = new RestRequest("api/dailyreturns/{region}/{date}");
            request.AddParameter("region", region);
            request.AddParameter("date", byDate.ToString("yyyy-MM-dd"));

            var response = await _client.ExecuteGetTaskAsync<DataViewModel>(request);

            return response.Data;
        }
    }
}