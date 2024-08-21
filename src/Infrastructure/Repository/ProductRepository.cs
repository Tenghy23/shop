namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;
        public ProductRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        //public async Task SaveDataAsync(IEnumerable<Product> products)
        //{
        //    try
        //    {
        //        _dbContext.Products.AddRange(products);

        //        // Save changes to the database
        //        await _dbContext.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Product SaveChangesAsync error: {ex.Message}");
        //    }
        //}

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Update(product);
        }

        public async Task SaveChangesAsync(ICancellationToken )
        {
            _dbContext.Products.AddRange(products);

        }

        public async Task SaveChangesAsync(IEnumerable<Product> products)
        {
            _dbContext.Products.AddRange(products);

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