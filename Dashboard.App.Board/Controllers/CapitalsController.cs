using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.App.Board.Domain.Contracts;
using Dashboard.App.Board.Models;

namespace Dashboard.App.Board.Controllers
{
    public class CapitalsController : ApiController
    {
        private readonly IDataApi _dataApi;
        private readonly ICapitalRepository _capitalRepository;

        public CapitalsController(IDataApi dataApi)
        {
            _dataApi = dataApi;
        }

        // GET: api/capitals
        public async Task<DataViewModel> Get()
        {
            return await _dataApi.ListCapitals();
        }
    }
}
