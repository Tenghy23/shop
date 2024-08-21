namespace Application.Models.DTOs
{
    public class ProductViewModel
    {
        public Guid InventoryId { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? DiscountFixedValue { get; set; }
    }
}
