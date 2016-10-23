using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Api.DataStore.Domain.Models;

namespace Dashboard.Api.DataStore.Domain.Contracts
{
    public interface ICapitalRepository
    {
        Task<IEnumerable<Capital>> ListBy(int strategyId);
    }
}