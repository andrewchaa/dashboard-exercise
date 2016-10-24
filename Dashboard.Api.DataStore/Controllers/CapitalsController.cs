using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Domain.Services;
using Dashboard.Api.DataStore.Models;

namespace Dashboard.Api.DataStore.Controllers
{
    public class CapitalsController : ApiController
    {
        private readonly ICrunchData _dataCruncher;

        public CapitalsController(ICrunchData dataCruncher)
        {
            _dataCruncher = dataCruncher;
        }

        // GET: api/Capitals
        public async Task<DataViewModel> Get()
        {
            var capitalsList = await _dataCruncher.ListMonthlyCapitals();
            return new DataViewModel
            {
                Labels = capitalsList.First().Select(c => c.Date.ToString("MM-yy")),
                Data = capitalsList.Select(c => c.Select(p => p.Amount)).ToList()
            };
        }

    }
}
