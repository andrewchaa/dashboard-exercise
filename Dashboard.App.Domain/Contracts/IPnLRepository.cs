using System.Threading.Tasks;
using Dashboard.App.Domain.Models;

namespace Dashboard.App.Domain.Contracts
{
    public interface IPnLRepository
    {
        Task<PnL> Add(PnL pnl);
    }
}