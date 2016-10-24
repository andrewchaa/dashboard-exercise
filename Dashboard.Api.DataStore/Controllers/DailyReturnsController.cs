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
    public class DailyReturnsController : ApiController
    {
        private readonly ICrunchData _dataCruncher;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();


        public DailyReturnsController(ICrunchData dataCruncher)
        {
            _dataCruncher = dataCruncher;
        }

        // GET: api/Capitals/ap
        [Route("api/dailyreturns/{region}/{date}")]
        public async Task<DataViewModel> Get(string region, string date)
        {
            Logger.Info("get request ... with {0} and {1}", region, date);

            var byDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var dailyReturns = await _dataCruncher.ListDailyReturns(
                region.ToUpper(), byDate);

            var labels = dailyReturns.First().Select(d => d.Date.ToShortDateString());
            var data = dailyReturns.Select(dr => dr.Select(d => d.DailyReturn).CumulativeSum()).ToList();
            

            return new DataViewModel
            {
                Labels = labels,
                Data = data
            };
        }


    }
}
