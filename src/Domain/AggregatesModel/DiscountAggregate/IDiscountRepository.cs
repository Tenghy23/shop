using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Domain.AggregatesModel.IDiscountRepository
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Discount>> RetrieveDiscountAsync(Expression<Func<Discount, bool>> criteria);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void AddDiscountAsync(List<Discount> discounts);
        void UpdateDiscountAsync(List<Discount> discounts);
        void UpdateDiscountAsync(Discount discount);
    }
}