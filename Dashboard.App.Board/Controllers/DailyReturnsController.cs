using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Dashboard.App.Board.Domain.Contracts;
using Dashboard.App.Board.Models;
using NLog;

namespace Dashboard.App.Board.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class DailyReturnsController : ApiController
    {
        private readonly IDataApi _dataApi;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public DailyReturnsController(IDataApi dataApi)
        {
            _dataApi = dataApi;
        }

        // GET: api/PnLs/2012-01-01
        [Route("api/dailyreturns/{region}/{date}")]
        public async Task<DataViewModel> Get(string region, string date)
        {
            Logger.Info("get request ... with {0} and {0}", region, date);

            var byDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var dataViewModel = await _dataApi.ListCumulativeReturns(region.ToUpper(), byDate);

            return dataViewModel;
        }
    }
}
