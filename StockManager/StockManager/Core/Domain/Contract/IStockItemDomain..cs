using StockManager.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManager.Core.Domain.Contract
{
    public interface IStockItemDomain
    {
        Task<IEnumerable<StockItem>> GetAllStockItems();
        Task AddStockItem(StockItem stockItem);
        Task UpdateStockItem(StockItem stockItem);
        Task DeleteStockItem(Guid stockItemId);
    }
}
