namespace Infrastructure.Data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly StoreDbContext _dbContext;
        public AddressRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        // HY to look into this again.. may not be the best way to save ...
        public async Task SaveDataAsync(IEnumerable<Address> addresses)
        {
            try
            {
                _dbContext.Address.AddRange(addresses);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Address SaveChangesAsync error: {ex.Message}");
            }
        }

    }
}