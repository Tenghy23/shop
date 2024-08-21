namespace Domain.AggregatesModel.InventoryAggregate
{
    public interface IInventoryRepository
    {
        Task SaveDataAsync(IEnumerable<Inventory> inventories);
    }
}
