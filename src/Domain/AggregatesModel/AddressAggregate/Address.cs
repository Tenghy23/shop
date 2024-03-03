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

        public Address(Guid? userId, string? addressLine1, string? addressLine2, 
            string? city, int? postalCode, string? country, string? mobileNumber, string? email)
        {
            UserId = userId;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            PostalCode = postalCode;
            Country = country;
            MobileNumber = mobileNumber;
            Email = email;
        }
    }
}