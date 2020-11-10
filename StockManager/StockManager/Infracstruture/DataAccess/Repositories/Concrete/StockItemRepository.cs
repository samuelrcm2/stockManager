using StockManager.Core.Domain.Models;
using StockManager.Infracstruture.DataAccess.Repositories.Caontract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManager.Infracstruture.DataAccess.Repositories
{
    public class StockItemRepository : IStockItemRepository
    {
        private IBaseRepository _baseRepository;
        public StockItemRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<StockItem>> GetAllStockItemsAsync()
        {
            string query = @"SELECT * FROM StockItems WHERE IsDeleted = 0 OR IsDeleted IS NULL";
            return await _baseRepository.FindAllAsync<StockItem>(query);
        }

        public async Task AddStockItemAsync(StockItem stockItem)
        {
            string query = @$"INSERT INTO StockItems (Id, Name, Amount, UnitPrice) VALUES 
                                    (@Id, @Name, @Amount, @UnitPrice)";
            await _baseRepository.AddAsync(stockItem, query);
        }

        public async Task UpdateStockItemAsync(StockItem stockItem)
        {
            string query = $@"UPDATE StockItems
                                SET Name = @Name,
                                    Amount = @Amount,
                                    UnitPrice = @UnitPrice
                                WHERE
                                    lower(Id) = lower('{stockItem.Id}')";
            await _baseRepository.UpdateAsync(stockItem, query);
        }

        public async Task DeleteStockItemAsync(Guid stockItemId)
        {
            string query = $"UPDATE StockItems SET IsDeleted = 1 WHERE lower(Id) = lower('{stockItemId}')";
            await _baseRepository.DeleteAsync(query);
        }
    }
}
