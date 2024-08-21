using Domain.AggregatesModel.CommonAggregate;
using Domain.AggregatesModel.ProductAggregate;

namespace Domain.AggregatesModel.CartAggregate
{
    public class Cart : BaseEntity
    {
        public Guid? UserId { get; private set; }
        public ICollection<Product> ProductList { get; set; }

        public Cart() { }
    }
}