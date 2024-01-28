using Domain.AggregatesModel.CommonAggregate;

namespace Domain.AggregatesModel.DiscountAggregate
{
    public class Discount : BaseEntity
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal? Percentage { get; private set; }
        public decimal? FixedValue { get; private set; }
        public bool Active { get; private set; }

        public Discount() { }
    }
}