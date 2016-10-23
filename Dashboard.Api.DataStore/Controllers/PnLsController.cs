using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Domain.Models;

namespace Dashboard.Api.DataStore.Controllers
{
    public class PnLsController : ApiController
    {
        private readonly IPnLRepository _repository;

        public PnLsController(IPnLRepository repository)
        {
            _repository = repository;
        }

        // GET: api/PnLs/2012-01-01
        [Route("api/PnLs/{date}")]
        public async Task<IEnumerable<PnLByRegion>> Get(string date)
        {
            var byDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var pnlViewModel = await _repository.ListByRegion(byDate);

            return pnlViewModel;
        }
    }
}
