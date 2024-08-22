using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Domain.AggregatesModel.ProductAggregate
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> RetrieveProductAsync(Expression<Func<Product, bool>> criteria);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void AddProductAsync(List<Product> products);
        void UpdateProductAsync(List<Product> products);
        void UpdateProductAsync(Product product);
    }
}