namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> ConvertProductsToProductsDto(IReadOnlyList<Product> products);
    }
}
