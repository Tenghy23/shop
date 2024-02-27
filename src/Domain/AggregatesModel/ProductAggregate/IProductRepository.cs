using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.ProductAggregate
{
    public interface IProductRepository
    {
        Task SaveDataAsync(IEnumerable<Product> products);
        Task<Product> GetProductByIdAsync(Guid id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}
