using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Domain.AggregatesModel.AddressAggregate
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> RetrieveAddressAsync(Expression<Func<Address, bool>> criteria);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void AddAddressAsync(List<Address> address);
        void UpdateAddressAsync(List<Address> address);
        void UpdateAddressAsync(Address address);
    }
}
