using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDomainService _productDomainService;
        private readonly IProductRepository _productRepository;

        public ProductService(
            IProductDomainService productDomainService,
            IProductRepository productRepository
            ) 
        {
            _productDomainService = productDomainService;
            _productRepository = productRepository;
        }

        public async Task<string> SeedProductsAndInventory(int count)
        {
            if (count > 10000)
            {
                return "Only provide Input count < 10000 records, no data is seeded";
            } 
            else
            {
                return await _productDomainService.SeedProductsAndInventory(count);
            }
        }

    }
}
