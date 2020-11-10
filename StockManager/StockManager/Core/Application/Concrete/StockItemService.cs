
using StockManager.Core.Domain.Contract;
using StockManager.Core.Application.Contract;
using AutoMapper;
using System.Collections.Generic;
using StockManager.Core.Domain.Models;
using System.Threading.Tasks;
using StockManager.Core.Application.ViewModels;
using System;

namespace StockManager.Core.Application.Concrete
{
    public class StockItemService : IStockItemService
    {
        public IStockItemDomain _stockItemDomain { get; set; }
        public IMapper _mapper { get; set; }
        public StockItemService(IStockItemDomain stockItemDomain, IMapper mapper)
        {
            _stockItemDomain = stockItemDomain;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockItemViewModel>> GetAllStockItems()
        {
            IEnumerable<StockItem> allStockItems = await _stockItemDomain.GetAllStockItems();
            return _mapper.Map<IEnumerable<StockItemViewModel>>(allStockItems);
        }

        public async Task AddStockItem(StockItemViewModel stockItemViewModel)
        {
            StockItem stockItem = _mapper.Map<StockItem>(stockItemViewModel);
            await _stockItemDomain.AddStockItem(stockItem);
        }

        public async Task UpdateStockItem(StockItemViewModel stockItemViewModel)
        {
            StockItem stockItem = _mapper.Map<StockItem>(stockItemViewModel);
            await _stockItemDomain.UpdateStockItem(stockItem);
        }

        public async Task DeleteStockItem(Guid stockItemId)
        {
            await _stockItemDomain.DeleteStockItem(stockItemId);
        }
    }
}
