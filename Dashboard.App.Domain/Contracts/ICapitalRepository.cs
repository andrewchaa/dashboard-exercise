using System.Threading.Tasks;
using Dashboard.App.Domain.Models;

namespace Dashboard.App.Domain.Contracts
{
    public interface ICapitalRepository
    {
        Task<Capital> Add(Capital pnl);
    }
}