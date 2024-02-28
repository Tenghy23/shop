namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<string> SeedProductsAndInventory(int count);
    }
}
