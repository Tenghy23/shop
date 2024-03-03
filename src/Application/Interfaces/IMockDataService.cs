namespace Application.Interfaces
{
    public interface IMockDataService
    {
        Task<string> MockProductsAndInventory(int count);
        Task<string> MockCategory(int count);
    }
}
