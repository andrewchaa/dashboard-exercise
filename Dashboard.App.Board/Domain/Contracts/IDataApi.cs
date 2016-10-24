using System;
using System.Threading.Tasks;
using Dashboard.App.Board.Models;

namespace Dashboard.App.Board.Domain.Contracts
{
    public interface IDataApi
    {
        Task<DataViewModel> ListCumulativePnLs(DateTime byDate);
        Task<DataViewModel> ListCapitals();
        Task<DataViewModel> ListCumulativeReturns(string region, DateTime byDate);
    }
}