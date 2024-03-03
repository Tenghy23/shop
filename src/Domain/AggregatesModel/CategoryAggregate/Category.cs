using Domain.AggregatesModel.CommonAggregate;

namespace Domain.AggregatesModel.CategoryAggregate
{
    public class Category : BaseEntity
    {
        public Guid? ProductId { get; private set; }
        public string CategoryName { get; private set; }
        public string? Description { get; private set; }

        public Category(string categoryName, Guid? productId, string? description)
        {
            CategoryName = categoryName;
            ProductId = productId;
            Description = description;
        }
    }
}
