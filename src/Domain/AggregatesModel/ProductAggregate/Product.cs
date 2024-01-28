using Domain.AggregatesModel.CategoryAggregate;
using Domain.AggregatesModel.CommonAggregate;
using Domain.AggregatesModel.DiscountAggregate;

namespace Domain.AggregatesModel.ProductAggregate
{
    public class Product : BaseEntity
    {
        public Guid InventoryId { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Name { get; private set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public ICollection<Discount>? Discount { get; set; }

        public Product() { }
    }
}