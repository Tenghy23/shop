namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> ConvertProductsToProductsDto(IEnumerable<Product> products);
    }
}
