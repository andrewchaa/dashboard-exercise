using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.App.Board.Domain.Contracts;
using Dashboard.App.Board.Helpers;
using Dashboard.App.Board.Models;

namespace Dashboard.App.Board.Controllers
{
    public class PnLsController : ApiController
    {
        private readonly IPnLRepository _repository;

        public PnLsController(IPnLRepository repository)
        {
            _repository = repository;
        }

        // GET: api/PnLs
//        public async Task<DataViewModel> Get()
//        {
//            var pnls = await _repository.ListByRegion(new DateTime(2010, 5, 31));
//            var labels = pnls.Where(p => p.Region == "AP")
//                .Select(p => p.Date.ToShortDateString());
//            var aps = pnls.Where(p => p.Region == "AP").Select(p => p.Amount).CumulativeSum().ToList();
//            var eus = pnls.Where(p => p.Region == "EU").Select(p => p.Amount).CumulativeSum().ToList();
//            var uses = pnls.Where(p => p.Region == "US").Select(p => p.Amount).CumulativeSum().ToList();
//
//            var pnlViewModel = new DataViewModel
//            {
//                Labels = labels,
//                Data = new List<List<decimal>>
//                {
//                    aps, eus, uses
//                }
//            };
//
//            return pnlViewModel;
//        }

        // GET: api/PnLs/2012-01-01
        [Route("api/PnLs/{date}")]
        public async Task<DataViewModel> Get(string date)
        {
            var pnls = await _repository.ListByRegion(DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture));
            var labels = pnls.Where(p => p.Region == "AP")
                .Select(p => p.Date.ToShortDateString());
            var aps = pnls.Where(p => p.Region == "AP").Select(p => p.Amount).CumulativeSum().ToList();
            var eus = pnls.Where(p => p.Region == "EU").Select(p => p.Amount).CumulativeSum().ToList();
            var uses = pnls.Where(p => p.Region == "US").Select(p => p.Amount).CumulativeSum().ToList();

            var pnlViewModel = new DataViewModel
            {
                Labels = labels,
                Data = new List<List<decimal>>
                {
                    aps, eus, uses
                }
            };

            return pnlViewModel;
        }

        // POST: api/PnLs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PnLs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PnLs/5
        public void Delete(int id)
        {
        }
    }
}
