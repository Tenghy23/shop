using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;
        public ProductRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Product>> RetrieveProductAsync(Expression<Func<Product, bool>> criteria)
        {
            IQueryable<Product> query = _dbContext.Products
                .AsNoTracking()
                .AsSplitQuery()
                .Where(criteria);

            return await query.ToListAsync() ?? Enumerable.Empty<Product>();
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