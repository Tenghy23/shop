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

        public async Task<string> SeedProducts(int count)
        {
            try
            {
                var inventories = new List<Inventory>();
                var products = new List<Product>();

                for(int i = 0; i < count; i++)
                {
                    var randomizerFirstName = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
                    var randomizerDescription = RandomizerFactory.GetRandomizer(new FieldOptionsTextLipsum());
                
                    var newId = Guid.NewGuid();
                    var invCount = new Random().Next(501);
                    var price =  Math.Round((decimal)(new Random().NextDouble() * 199) + 1, 2);
                    var name = randomizerFirstName.Generate();
                    var description = randomizerDescription.Generate();

                    var mockInventory = new Inventory(newId, invCount);
                    var mockProduct = new Product(newId, null ,name, description, 0, price);

                    inventories.Add(mockInventory);
                    Console.WriteLine($"{i} inventories seeded");

                    products.Add(mockProduct);
                    Console.WriteLine($"{i} products seeded");
                }

                await _productRepository.SaveDataAsync(products);
                await _inventoryRepository.SaveDataAsync(inventories);

                return $"{count} products successfully seeded";
            }
            catch (Exception ex)
            {
                throw new Exception("Error seeding products, no data seeded");
            }
        }

    }
}
