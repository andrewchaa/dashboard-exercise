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
        private readonly ICumulativePnLStore _cumulativePnLStore;

        public PnLsController(ICumulativePnLStore cumulativePnLStore)
        {
            _cumulativePnLStore = cumulativePnLStore;
        }

        // GET: api/PnLs/2012-01-01
        [Route("api/PnLs/{date}")]
        public async Task<DataViewModel> Get(string date)
        {
            var byDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var pnlViewModel = await _cumulativePnLStore.ListCumulativePnL(byDate);

            return pnlViewModel;
        }
    }
}
