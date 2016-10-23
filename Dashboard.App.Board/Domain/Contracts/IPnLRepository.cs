using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.App.Board.Domain.Models;

namespace Dashboard.App.Board.Domain.Contracts
{
    public interface IPnLRepository
    {
        Task<IEnumerable<PnL>> List();
        Task<IEnumerable<PnLByRegion>> ListByRegion();

    }
}