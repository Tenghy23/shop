using Microsoft.EntityFrameworkCore;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace Domain.AggregatesModel.ProductAggregate
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _productRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public ProductDomainService(
            IProductRepository productRepository,
            IInventoryRepository inventoryRepository
            )
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
        }


    }
}
