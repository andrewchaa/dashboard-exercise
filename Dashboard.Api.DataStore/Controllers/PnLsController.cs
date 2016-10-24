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

        public PnLsController(IPnLRepository _pnlRepository)
        {
            this._pnlRepository = _pnlRepository;
        }

        // GET: api/PnLs/2012-01-01
        [Route("api/PnLs/{date}")]
        public async Task<DataViewModel> Get(string date)
        {
            var byDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var pnls = await _pnlRepository.ListByRegion(byDate);

            var labels = pnls.Where(p => p.Region == "AP").Select(p => p.Date.ToShortDateString());
            var aps = pnls.Where(p => p.Region == "AP").Select(p => p.Amount).CumulativeSum().ToList();
            var eus = pnls.Where(p => p.Region == "EU").Select(p => p.Amount).CumulativeSum().ToList();
            var uses = pnls.Where(p => p.Region == "US").Select(p => p.Amount).CumulativeSum().ToList();

            return new DataViewModel
            {
                Labels = labels.ToList(),
                Data = new List<List<decimal>>
                {
                    aps, eus, uses
                }
            };
        }
    }
}
