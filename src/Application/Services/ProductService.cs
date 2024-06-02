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

        public async Task<List<ProductViewModel>> ConvertProductsToProductsDto(IReadOnlyList<Product> products)
        {
            var listOfProductDto = new List<ProductViewModel();
            foreach (var i in products)
            {
                listOfProductDto.Add(new ProductViewModel()
                {
                    InventoryId = i.InventoryId,
                    CategoryId = i.CategoryId,
                    Name = i.Name,
                    Description = i.Description,
                    Quantity = i.Quantity,
                    Price = i.Price,
                    DiscountPercentage = i.Discount.FirstOrDefault(x => x.Active is true).Percentage,
                    DiscountFixedValue = i.Discount.FirstOrDefault(x => x.Active is true).FixedValue
                });
            }
            return listOfProductDto;
        }
    }
}
