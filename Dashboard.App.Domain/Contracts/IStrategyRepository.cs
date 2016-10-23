using System.Threading.Tasks;
using Dashboard.App.Domain.Models;

namespace Dashboard.App.Domain.Contracts
{
    public interface IStrategyRepository
    {
        Task<Strategy> Add(Strategy pnl);
    }
}