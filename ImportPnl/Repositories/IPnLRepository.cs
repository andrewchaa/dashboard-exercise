using System.Threading.Tasks;
using Dashboard.App.ImportPnl.Domain.Models;

namespace Dashboard.App.ImportPnl.Repositories
{
    public interface IPnLRepository
    {
        Task<PnL> Add(PnL pnl);
    }
}