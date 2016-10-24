using System;
using System.Threading.Tasks;
using Dashboard.Api.DataStore.Domain.Models;
using System.Collections.Generic;

namespace Dashboard.Api.DataStore.Domain.Contracts
{
    public interface ICrunchData
    {
        Task<IEnumerable<IEnumerable<PnLDailyReturn>>> ListDailyReturns(string region, DateTime byDate);
        Task<IEnumerable<IEnumerable<Capital>>> ListMonthlyCapitals();
        Task<IEnumerable<IEnumerable<PnLByRegion>>> ListPnLs(DateTime byDate);
    }
}