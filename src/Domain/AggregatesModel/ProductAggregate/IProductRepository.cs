namespace Domain.AggregatesModel.ProductAggregate
{
    public interface IProductRepository
    {
        Task SaveDataAsync(IEnumerable<Product> products);
        Task<Product> GetProductByIdAsync(Guid id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}