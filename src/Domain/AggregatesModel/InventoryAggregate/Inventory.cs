using Domain.AggregatesModel.CommonAggregate;
using Domain.AggregatesModel.ProductAggregate;

namespace Domain.AggregatesModel.InventoryAggregate
{
    public class Inventory : BaseEntity
    {
        public Product Product { get; private set; }
        public int StockRemaining { get; private set; }

        public Inventory() { }
    }
}