namespace Domain.Entities
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }
        public List<Product> ProductList { get; set; }

        public Cart() { }
    }
}