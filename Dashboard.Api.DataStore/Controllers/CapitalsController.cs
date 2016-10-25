using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Models;
using NLog;

namespace Dashboard.Api.DataStore.Controllers
{
    public class CapitalsController : ApiController
    {
        private readonly ICrunchData _dataCruncher;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public CapitalsController(ICrunchData dataCruncher)
        {
            _dataCruncher = dataCruncher;
        }

        // GET: api/Capitals
        public async Task<DataViewModel> Get()
        {
            Logger.Info("get request ...");

            var capitalsList = await _dataCruncher.ListMonthlyCapitals();
            return new DataViewModel
            {
                labels = capitalsList.First().Select(c => c.Date.ToString("MM-yy")),
                series = capitalsList.Select(c => c.Select(p => p.Amount)).ToList()
            };
        }

    }
}
