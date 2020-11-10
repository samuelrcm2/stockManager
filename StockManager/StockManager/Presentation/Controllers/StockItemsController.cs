using Microsoft.AspNetCore.Mvc;
using StockManager.Core.Application.Contract;
using StockManager.Core.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace StockManager.Presentation.Controllers
{
    [Route("api/StockItems")]
    public class StockItemsController : ApiController
    {

        public IStockItemService _stockItemService { get; set; }

        public StockItemsController(IStockItemService stockItemService)
        {
            _stockItemService = stockItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStockItems()
        {
            try
            {
                return SendOkResponse(await _stockItemService.GetAllStockItems());
            }
            catch (Exception ex)
            {
                return SendErrorResponse(ex.Message);
            }
        }
        
        [Route("addStockItem")]
        [HttpPost]
        public async Task<IActionResult> AddStockItem(StockItemViewModel stockItem)
        {
            try
            {
                await _stockItemService.AddStockItem(stockItem);
                return SendOkResponse();
            }
            catch (Exception ex)
            {
                return SendErrorResponse(ex.Message);
            }
        }

        [Route("updateStockItem")]
        [HttpPost]
        public async Task<IActionResult> UpdateStockItem(StockItemViewModel stockItem)
        {
            try
            {
                await _stockItemService.UpdateStockItem(stockItem);
                return SendOkResponse();
            }
            catch (Exception ex)
            {
                return SendErrorResponse(ex.Message);
            }
        }

        [Route("deleteStockItem")]
        [HttpPost]
        public async Task<IActionResult> DeleteStockItem(Guid stockItemId)
        {
            try
            {
                await _stockItemService.DeleteStockItem(stockItemId);
                return SendOkResponse();
            }
            catch (Exception ex)
            {
                return SendErrorResponse(ex.Message);
            }
        }
    }
}
