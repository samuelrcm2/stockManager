using StockManager.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManager.Core.Application.Contract
{
    public interface IStockItemService
    {
        Task<IEnumerable<StockItemViewModel>> GetAllStockItems();
        Task AddStockItem(StockItemViewModel stockItemViewModel);
        Task UpdateStockItem(StockItemViewModel stockItemViewModel);
        Task DeleteStockItem(Guid stockItemId);
    }
}
