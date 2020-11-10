using StockManager.Core.Domain.Contract;
using StockManager.Core.Domain.Models;
using StockManager.Infracstruture.DataAccess.Repositories.Caontract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManager.Core.Domain.Concrete
{
    public class StockItemDomain : IStockItemDomain
    {
        private readonly IStockItemRepository _stockItemRepository;
        public StockItemDomain(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }
        public async Task<IEnumerable<StockItem>> GetAllStockItems()
        {
            return await _stockItemRepository.GetAllStockItemsAsync();
        }
        
        public async Task AddStockItem(StockItem stockItem)
        {
            stockItem.SetId(Guid.NewGuid());
            await _stockItemRepository.AddStockItemAsync(stockItem);
        }

        public async Task UpdateStockItem(StockItem stockItem)
        {
            await _stockItemRepository.UpdateStockItemAsync(stockItem);
        }
        public async Task DeleteStockItem(Guid stockItemId)
        {
            await _stockItemRepository.DeleteStockItemAsync(stockItemId);
        }
    }
}
