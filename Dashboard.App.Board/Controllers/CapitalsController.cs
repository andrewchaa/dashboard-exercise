using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.App.Board.Domain.Contracts;
using Dashboard.App.Board.Models;
using NLog;

namespace Dashboard.App.Board.Controllers
{
    public class CapitalsController : ApiController
    {
        private readonly IDataApi _dataApi;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public CapitalsController(IDataApi dataApi)
        {
            _dataApi = dataApi;
        }

        // GET: api/capitals
        public async Task<DataViewModel> Get()
        {
            Logger.Info("get requeset ...");

            return await _dataApi.ListCapitals();
        }
    }
}
