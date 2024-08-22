using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;
        public CategoryRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Category>> RetrieveCategoryAsync(Expression<Func<Category, bool>> criteria)
        {
            IQueryable<Category> query = _dbContext.Category
                .AsNoTracking()
                .AsSplitQuery()
                .Where(criteria);

            return await query.ToListAsync() ?? Enumerable.Empty<Category>();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void AddCategoryAsync(List<Category> category)
        {
            _dbContext.AddRangeAsync(category);
        }

        public void UpdateCategoryAsync(List<Category> category)
        {
            _dbContext.UpdateRange(category);
        }

        public void UpdateCategoryAsync(Category category)
        {
            _dbContext.Update(category);
        }
    }
}