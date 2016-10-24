using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Helpers;
using Dashboard.Api.DataStore.Models;

namespace Dashboard.Api.DataStore.Controllers
{
    public class PnLsController : ApiController
    {
        private readonly IPnLRepository _pnlRepository;
        private readonly ICrunchData _dataCruncher;

        public PnLsController(IPnLRepository _pnlRepository, ICrunchData dataCruncher)
        {
            this._pnlRepository = _pnlRepository;
            _dataCruncher = dataCruncher;
        }

        // GET: api/PnLs/2012-01-01
        [Route("api/PnLs/{date}")]
        public async Task<DataViewModel> Get(string date)
        {
            var byDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var pnlsList = await _dataCruncher.ListPnLs(byDate);

            return new DataViewModel
            {
                Labels = pnlsList.First().Select(p => p.Date.ToShortDateString()),
                Data = pnlsList.Select(p => p.Select(n => n.Amount).CumulativeSum())
            };
        }
    }
}
