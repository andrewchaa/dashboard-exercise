using System;
using System.Threading.Tasks;
using Dashboard.App.Board.Models;

namespace Dashboard.App.Board.Domain.Contracts
{
    public interface ICumulativePnLStore
    {
        Task<DataViewModel> ListCumulativePnL(DateTime byDate);
    }
}