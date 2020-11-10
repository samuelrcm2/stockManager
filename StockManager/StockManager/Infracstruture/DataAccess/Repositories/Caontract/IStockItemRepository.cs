using StockManager.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManager.Infracstruture.DataAccess.Repositories.Caontract
{
    public interface IStockItemRepository
    {
        Task<IEnumerable<StockItem>> GetAllStockItemsAsync();
        Task AddStockItemAsync(StockItem stockItem);
        Task UpdateStockItemAsync(StockItem stockItem);
        Task DeleteStockItemAsync(Guid stockItemId);
    }
}
