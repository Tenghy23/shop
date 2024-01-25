namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid InventoryId { get; set; }
        public string Name { get; private set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Discount Discount { get; set; }

        public Product() { }
    }
}