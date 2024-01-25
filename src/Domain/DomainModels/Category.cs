namespace Domain.DomainModels
{
    public class Category : BaseEntity
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public int Description { get; private set; }

        public Category() { }
    }
}
