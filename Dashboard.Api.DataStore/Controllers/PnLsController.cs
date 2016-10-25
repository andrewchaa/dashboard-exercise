using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Helpers;
using Dashboard.Api.DataStore.Models;
using NLog;

namespace Dashboard.Api.DataStore.Controllers
{
    public class PnLsController : ApiController
    {
        private readonly ICrunchData _dataCruncher;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public PnLsController(ICrunchData dataCruncher)
        {
            _dataCruncher = dataCruncher;
        }

        // GET: api/PnLs/2012-01-01
        [Route("api/PnLs/{date}")]
        public async Task<DataViewModel> Get(string date)
        {
            Logger.Info("get request ... with {0}", date);

            var byDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var pnlsList = await _dataCruncher.ListPnLs(byDate);

            return new DataViewModel
            {
                labels = pnlsList.First().Select(p => p.Date.ToShortDateString()),
                series = pnlsList.Select(p => p.Select(n => n.Amount).CumulativeSum())
            };
        }
    }
}
