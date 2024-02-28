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

    }
}
