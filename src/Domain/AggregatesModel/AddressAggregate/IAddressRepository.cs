namespace Domain.AggregatesModel.AddressAggregate
{
    public interface IAddressRepository
    {
        Task SaveDataAsync(IEnumerable<Address> addresses);
    }
}
