using System;
using System.Threading.Tasks;
using Dashboard.Api.DataStore.Domain.Models;
using System.Collections.Generic;

namespace Dashboard.Api.DataStore.Domain.Contracts
{
    public interface ICrunchData
    {
        Task<IEnumerable<IEnumerable<PnLDailyReturn>>> ListAccumulativeReturn(string region, DateTime byDate);
    }
}