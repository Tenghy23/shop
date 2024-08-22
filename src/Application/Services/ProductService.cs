namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDomainService _productDomainService;

        public ProductService(
            IProductDomainService productDomainService
            ) 
        {
            _productDomainService = productDomainService;
        }

        public async Task<IEnumerable<ProductViewModel>> ConvertProductsToProductsDto(IEnumerable<Product> products)
        {
            return products.Select(x => new ProductViewModel()
            {
                InventoryId = x.InventoryId,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Description = x.Description,
                Quantity = x.Quantity,
                Price = x.Price,
                DiscountPercentage = x.Discount.FirstOrDefault(x => x.Active is true).Percentage,
                DiscountFixedValue = x.Discount.FirstOrDefault(x => x.Active is true).FixedValue
            });
        }
    }
}
