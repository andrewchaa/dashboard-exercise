using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.App.Board.Domain.Contracts;

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
        public async Task<PnLViewModel> Get()
        {
            var pnls = await _repository.ListByRegion();
            var labels = pnls.Where(p => p.Region == "AP")
                .Select(p => p.Date.ToShortDateString());
            var aps = pnls.Where(p => p.Region == "AP").Select(p => p.Amount).ToList();
            var eus = pnls.Where(p => p.Region == "EU").Select(p => p.Amount).ToList();
            var uses = pnls.Where(p => p.Region == "US").Select(p => p.Amount).ToList();

            var pnlViewModel = new PnLViewModel
            {
//                Labels = new List<string> { "2014-02-01", "2014-02-02", "2014-02-03" },
                Labels = labels,
                Data = new List<List<decimal>>
                {
                    aps, eus, uses
                }
//                Data = new List<List<decimal>>
//                {
//                    new List<decimal> { 11m, 13m, 15m },
//                    new List<decimal> { 12m, 11m, 16m },
//                    new List<decimal> { 10m, 16m, 14m },
//                }
            };

            return pnlViewModel;
        }

        // GET: api/PnLs/5
        public string Get(int id)
        {
            return "value";
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

    public class PnLViewModel
    {
        public IEnumerable<string> Labels { get; set; }
        public IEnumerable<IEnumerable<decimal>> Data { get; set; }
    }
}
