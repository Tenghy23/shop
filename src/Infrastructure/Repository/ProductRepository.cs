using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;
        public ProductRepository(StoreDbContext context, IMemoryCache memoryCache)
        {
            _dbContext = context;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Product>> RetrieveProductAsync(Expression<Func<Product, bool>> criteria)
        {
            IQueryable<Product> query = _dbContext.Products
                .AsNoTracking()
                .AsSplitQuery()
                .Where(criteria);

            return await query.ToListAsync() ?? Enumerable.Empty<Product>();
        }

        public async Task<IEnumerable<Product>> RetrieveProductAsync(Guid id)
        {
            // Generate a unique cache key based on the method and parameters
            string cacheKey = $"Product_{id}";

            // Try to retrieve the result from the cache
            if (_memoryCache.TryGetValue(cacheKey, out IEnumerable<Product> cachedProducts))
            {
                return cachedProducts;
            }

            // If not cached, query the database
            var query = _dbContext.Products
                .AsNoTracking()
                .AsSplitQuery()
                .Where(x => x.Id == id);

            var products = await query.ToListAsync() ?? Enumerable.Empty<Product>();

            // Cache the result with a sliding expiration of 10 minutes
            _memoryCache.Set(cacheKey, products, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(10)
            });

            return products;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void AddProductAsync(List<Product> products)
        {
            _dbContext.AddRangeAsync(products);
        }

        public void UpdateProductAsync(List<Product> products)
        {
            _dbContext.UpdateRange(products);
        }

        public void UpdateProductAsync(Product product)
        {
            _dbContext.Update(product);
        }
    }
}