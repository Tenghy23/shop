using Domain.AggregatesModel.CommonAggregate;

namespace Domain.AggregatesModel.AddressAggregate
{
    public class Address : BaseEntity
    {
        public Guid? UserId { get; private set; }
        public string? AddressLine1 { get; private set; }
        public string? AddressLine2 { get; private set; }
        public string? City { get; private set; }
        public int? PostalCode { get; private set; }
        public string? Country { get; private set; }
        public string? MobileNumber { get; private set; }
        public string? Email { get; private set; }

        public Address() { }
    }
}