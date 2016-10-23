using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Api.DataStore.Domain.Models;

namespace Dashboard.Api.DataStore.Domain.Contracts
{
    public interface IStrategyRepository
    {
        Task<IEnumerable<Strategy>> ListBy(string region);
    }
}