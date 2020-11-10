using System;

namespace StockManager.Core.Application.ViewModels
{
    public class StockItemViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int UnitPrice { get; set; }
    }
}