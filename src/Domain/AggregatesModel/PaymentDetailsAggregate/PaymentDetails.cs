using Domain.AggregatesModel.CommonAggregate;

namespace Domain.AggregatesModel.PaymentDetailsAggregate
{
    public class PaymentDetails : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public decimal Amount { get; set; }
        public string Provider { get; set; }
        public string Status { get; set; }

        public PaymentDetails() { }
    }
}