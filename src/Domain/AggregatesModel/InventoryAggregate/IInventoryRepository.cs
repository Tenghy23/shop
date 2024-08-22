using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Domain.AggregatesModel.InventoryAggregate
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> RetrieveInventoryAsync(Expression<Func<Inventory, bool>> criteria);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void AddInventoryAsync(List<Inventory> inventories);
        void UpdateInventoryAsync(List<Inventory> inventories);
        void UpdateInventoryAsync(Inventory inventory);
    }
}
