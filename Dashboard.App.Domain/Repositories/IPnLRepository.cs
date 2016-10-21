using System.Threading.Tasks;
using Dashboard.App.Domain.Models;

namespace Dashboard.App.Domain.Repositories
{
    public interface IPnLRepository
    {
        Task<PnL> Add(PnL pnl);
    }
}