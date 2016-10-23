using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.App.Board.Domain.Models;

namespace Dashboard.App.Board.Domain.Contracts
{
    public interface ICapitalRepository
    {
        Task<IEnumerable<Capital>> ListBy(int strategyId);
    }


}