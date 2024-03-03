namespace Domain.Helpers.MockData
{
    public class MockDataDomainService : IMockDataDomainService
    {
        private readonly IProductRepository _productRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MockDataDomainService(
            IProductRepository productRepository,
            IInventoryRepository inventoryRepository,
            ICategoryRepository categoryRepository
            )
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<string> MockProductsAndInventory(int count)
        {
            try
            {
                var inventories = new List<Inventory>();
                var products = new List<Product>();

                for (int i = 0; i < count; i++)
                {
                    var randomizerFirstName = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
                    var randomizerDescription = RandomizerFactory.GetRandomizer(new FieldOptionsTextLipsum());

                    var newId = Guid.NewGuid();
                    var invCount = new Random().Next(501);
                    var price = Math.Round((decimal)(new Random().NextDouble() * 199) + 1, 2);
                    var name = randomizerFirstName.Generate();
                    var description = randomizerDescription.Generate();

                    var mockInventory = new Inventory(newId, invCount);
                    var mockProduct = new Product(newId, null, name, description, 0, price);

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
                throw new Exception($"Error seeding products, no data seeded, Error: {ex}");
            }
        }

        public async Task<string> MockCategory(int count)
        {
            try
            {
                var categories = new List<Category>();

                for (int i = 0; i < count; i++)
                {
                    var randomizerFirstName = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
                    var randomizerDescription = RandomizerFactory.GetRandomizer(new FieldOptionsTextLipsum());

                    var name = randomizerFirstName.Generate();
                    var description = randomizerDescription.Generate();

                    var mockCategory = new Category(name, null, description);

                    categories.Add(mockCategory);
                    Console.WriteLine($"{i} categories seeded");
                }

                await _categoryRepository.SaveDataAsync(categories);

                return $"{count} products successfully seeded";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error seeding products, no data seeded, Error: {ex}");
            }
        }


    }
}
