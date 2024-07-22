namespace Domain.AggregatesModel.ProductAggregate
{
    public interface IMockDataDomainService
    {
        Task<string> MockProductsInventoryDiscount(int count);
        Task<string> MockCategory(int count);
        Task<string> MockAddress(int count);
    }
}
