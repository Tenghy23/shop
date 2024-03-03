namespace Domain.AggregatesModel.ProductAggregate
{
    public interface IMockDataDomainService
    {
        Task<string> MockProductsAndInventory(int count);
        Task<string> MockCategory(int count);
    }
}
