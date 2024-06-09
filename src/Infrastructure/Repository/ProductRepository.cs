namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;
        public ProductRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        // HY to look into this again.. may not be the best way to save ...
        public async Task SaveDataAsync(IEnumerable<Product> products)
        {
            try
            {
                _dbContext.Products.AddRange(products);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Product SaveChangesAsync error: {ex.Message}");
            }
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.Include(x => x.Discount).ToListAsync();
        }
    }
}