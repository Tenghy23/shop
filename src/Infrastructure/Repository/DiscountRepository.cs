namespace Infrastructure.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly StoreDbContext _dbContext;
        public DiscountRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        // HY to look into this again.. may not be the best way to save ...
        public async Task SaveDataAsync(IEnumerable<Discount> discount)
        {
            try
            {
                _dbContext.Discount.AddRange(discount);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Discount SaveChangesAsync error: {ex.Message}");
            }
        }
    }
}