using Domain.AggregatesModel.CommonAggregate;

namespace Domain.AggregatesModel.CategoryAggregate
{
    public class Category : BaseEntity
    {
        public Guid? ProductId { get; private set; }
        public string? CategoryName { get; private set; }
        public string? Description { get; private set; }

        public Category(Guid? productId, string? categoryName, string? description)
        {
            ProductId = productId;
            CategoryName = categoryName;
            Description = description;
        }
    }
}
