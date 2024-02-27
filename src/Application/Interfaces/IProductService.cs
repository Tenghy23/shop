namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<string> SeedProducts(int count);
    }
}
