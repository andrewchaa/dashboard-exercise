using System.Threading.Tasks;
using Dashboard.App.Domain.Models;

namespace Dashboard.App.Domain.Repositories
{
    public interface ICapitalRepository
    {
        Task<Capital> Add(Capital pnl);
    }
}