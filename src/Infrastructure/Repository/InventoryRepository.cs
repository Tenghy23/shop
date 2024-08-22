using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly StoreDbContext _dbContext;
        public InventoryRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Inventory>> RetrieveInventoryAsync(Expression<Func<Inventory, bool>> criteria)
        {
            IQueryable<Inventory> query = _dbContext.Inventory
                .AsNoTracking()
                .AsSplitQuery()
                .Where(criteria);

            return await query.ToListAsync() ?? Enumerable.Empty<Inventory>();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void AddInventoryAsync(List<Inventory> inventories)
        {
            _dbContext.AddRangeAsync(inventories);
        }

        public void UpdateInventoryAsync(List<Inventory> inventories)
        {
            _dbContext.UpdateRange(inventories);
        }

        public void UpdateInventoryAsync(Inventory inventory)
        {
            _dbContext.Update(inventory);
        }
    }
}