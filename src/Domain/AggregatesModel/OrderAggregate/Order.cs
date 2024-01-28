using Domain.AggregatesModel.CommonAggregate;
using Domain.AggregatesModel.OrderDetailsAggregate;
using Domain.AggregatesModel.PaymentDetailsAggregate;

namespace Domain.AggregatesModel.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; private set; }
        public decimal Total { get; private set; }
        public PaymentDetails PaymentDetails { get; private set; }
        public List<OrderDetails> OrderDetailsList { get; private set; }

        public Order() { }
    }
}
