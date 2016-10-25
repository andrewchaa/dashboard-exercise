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
    public class PnLsController : ApiController
    {
        private readonly IDataApi _dataApi;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public PnLsController(IDataApi dataApi)
        {
            _dataApi = dataApi;
        }

        // GET: api/PnLs/2012-01-01
        [Route("api/PnLs/{date}")]
        public async Task<DataViewModel> Get(string date)
        {
            Logger.Info("get request ... with {0}", date);

            var byDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var pnlViewModel = await _dataApi.ListCumulativePnLs(byDate);

            return pnlViewModel;
        }
    }
}
