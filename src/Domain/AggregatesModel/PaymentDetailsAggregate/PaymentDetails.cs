using Domain.AggregatesModel.CommonAggregate;

namespace Domain.AggregatesModel.PaymentDetailsAggregate
{
    public class PaymentDetails : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public decimal amount { get; set; }
        public string provider { get; set; }
        public string status { get; set; }

        public PaymentDetails() { }
    }
}