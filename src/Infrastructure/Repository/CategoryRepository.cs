namespace Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;
        public CategoryRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        // HY to look into this again.. may not be the best way to save ...
        public async Task SaveDataAsync(IEnumerable<Category> categories)
        {
            try
            {
                _dbContext.Category.AddRange(categories);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Inventory SaveChangesAsync error: {ex.Message}");
            }
        }

    }
}