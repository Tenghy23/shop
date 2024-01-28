using Domain.AggregatesModel.CommonAggregate;
using Domain.AggregatesModel.ProductAggregate;

namespace Domain.AggregatesModel.OrderDetailsAggregate
{
    public class OrderDetails : BaseEntity
    {
        public Guid? OrderId { get; private set; }
        public Guid? ProductId { get; private set; }
        public string Name { get; private set; }
        public int Description { get; private set; }

        public OrderDetails() { }
    }
}
