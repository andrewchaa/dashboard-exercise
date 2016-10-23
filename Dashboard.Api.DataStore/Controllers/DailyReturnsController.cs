using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Models;

namespace Dashboard.Api.DataStore.Controllers
{
    public class DailyReturnsController : ApiController
    {
        private readonly ICrunchData _dataCruncher;

        public DailyReturnsController(ICrunchData dataCruncher)
        {
            _dataCruncher = dataCruncher;
        }

        // GET: api/Capitals/ap
        [Route("api/dailyreturns/{region}/{date}")]
        public async Task<DataViewModel> Get(string region, string date)
        {
            var dailyReturns = await _dataCruncher.ListAccumulativeReturn(
                region.ToUpper(), DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture));

            var labels = dailyReturns.First().Select(d => d.Date.ToShortDateString());
            var data = dailyReturns.Select(dr => dr.Select(d => d.DailyReturn)).ToList();

            return new DataViewModel
            {
                Labels = labels,
                Data = data
            };
        }


    }
}
