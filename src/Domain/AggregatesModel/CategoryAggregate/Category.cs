using Domain.AggregatesModel.CommonAggregate;

namespace Domain.AggregatesModel.CategoryAggregate
{
    public class Category : BaseEntity
    {
        public Guid ProductId { get; private set; }
        public string? CategoryName { get; private set; }
        public int? Description { get; private set; }

        public Category() { }
    }
}
