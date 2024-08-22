using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly StoreDbContext _dbContext;
        public AddressRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Address>> RetrieveAddressAsync(Expression<Func<Address, bool>> criteria)
        {
            IQueryable<Address> query = _dbContext.Address
                .AsNoTracking()
                .AsSplitQuery()
                .Where(criteria);

            return await query.ToListAsync() ?? Enumerable.Empty<Address>();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void AddAddressAsync(List<Address> address)
        {
            _dbContext.AddRangeAsync(address);
        }

        public void UpdateAddressAsync(List<Address> address)
        {
            _dbContext.UpdateRange(address);
        }

        public void UpdateAddressAsync(Address address)
        {
            _dbContext.Update(address);
        }
    }
}