using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.App.Board.Domain.Contracts;
using Dashboard.App.Board.Models;

namespace Dashboard.App.Board.Controllers
{
    public class DailyReturnsController : ApiController
    {
        private readonly IDataApi _dataApi;

        public DailyReturnsController(IDataApi dataApi)
        {
            _dataApi = dataApi;
        }

        // GET: api/PnLs/2012-01-01
        [Route("api/dailyreturns/{region}/{date}")]
        public async Task<DataViewModel> Get(string region, string date)
        {
            var byDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var dataViewModel = await _dataApi.ListCumulativeReturns(region.ToUpper(), byDate);

            return dataViewModel;
        }
    }
}
