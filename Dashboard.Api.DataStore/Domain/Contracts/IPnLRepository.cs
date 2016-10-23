using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Api.DataStore.Domain.Models;

namespace Dashboard.Api.DataStore.Domain.Contracts
{
    public interface IPnLRepository
    {
        Task<IEnumerable<PnLByRegion>> ListByRegion(DateTime byDate);
        Task<IEnumerable<PnLCapital>> ListBy(int strategy, DateTime byDate);
    }
}