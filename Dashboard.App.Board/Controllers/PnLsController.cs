using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.App.Board.Domain.Contracts;
using Dashboard.App.Board.Models;

namespace Dashboard.App.Board.Controllers
{
    public class PnLsController : ApiController
    {
        private readonly IDataApi _dataApi;

        public PnLsController(IDataApi dataApi)
        {
            _dataApi = dataApi;
        }

        // GET: api/PnLs/2012-01-01
        [Route("api/PnLs/{date}")]
        public async Task<DataViewModel> Get(string date)
        {
            var byDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var pnlViewModel = await _dataApi.ListCumulativePnLs(byDate);

            return pnlViewModel;
        }
    }
}
