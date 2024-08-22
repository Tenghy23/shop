using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly StoreDbContext _dbContext;
        public DiscountRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Discount>> RetrieveDiscountAsync(Expression<Func<Discount, bool>> criteria)
        {
            IQueryable<Discount> query = _dbContext.Discount
                .AsNoTracking()
                .AsSplitQuery()
                .Where(criteria);

            return await query.ToListAsync() ?? Enumerable.Empty<Discount>();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void AddDiscountAsync(List<Discount> discounts)
        {
            _dbContext.AddRangeAsync(discounts);
        }

        public void UpdateDiscountAsync(List<Discount> discounts)
        {
            _dbContext.UpdateRange(discounts);
        }

        public void UpdateDiscountAsync(Discount discount)
        {
            _dbContext.Update(discount);
        }
    }
}