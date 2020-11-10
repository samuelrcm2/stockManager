using System;

namespace StockManager.Core.Domain.Models
{
    public class StockItem
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int UnitPrice { get; set; }
        public bool IsDeleted { get; set; }

        public void SetId(Guid id) => Id = id;
    }

}