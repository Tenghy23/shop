using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly StoreDbContext _dbContext;
        public InventoryRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        // HY to look into this again.. may not be the best way to save ...
        public async Task SaveDataAsync(IEnumerable<Inventory> inventories)
        {
            try
            {
                _dbContext.Inventory.AddRange(inventories);

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