namespace Domain.DomainModels
{
    public class OrderDetails : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public string Name { get; private set; }
        public int Description { get; private set; }
        public Product Product { get; private set; }

        public OrderDetails() { }
    }
}
