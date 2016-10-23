using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Domain.Models;
using Dashboard.Api.DataStore.Models;

namespace Dashboard.Api.DataStore.Controllers
{
    public class CapitalsController : ApiController
    {
        private readonly ICapitalRepository _capitalRepository;

        public CapitalsController(ICapitalRepository capitalRepository)
        {
            _capitalRepository = capitalRepository;
        }

        // GET: api/Capitals
        public async Task<DataViewModel> Get()
        {
            var capitals1 = await _capitalRepository.ListBy(1);
            var capitals4 = await _capitalRepository.ListBy(4);
            var capitals8 = await _capitalRepository.ListBy(8);
            var capitals9 = await _capitalRepository.ListBy(9);

            return new DataViewModel
            {
                Labels = capitals1.Select(c => c.Date.ToString("MM-yy")),
                Data = new List<List<decimal>>
                {
                    capitals1.Select(c => c.Amount).ToList(),
                    capitals4.Select(c => c.Amount).ToList(),
                    capitals8.Select(c => c.Amount).ToList(),
                    capitals9.Select(c => c.Amount).ToList()
                }
            };
        }

    }
}
