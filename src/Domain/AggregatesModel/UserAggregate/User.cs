using Domain.AggregatesModel.CartAggregate;
using Domain.AggregatesModel.CommonAggregate;
using Domain.AggregatesModel.PaymentDetailsAggregate;
using Domain.AggregatesModel.AddressAggregate;

namespace Domain.AggregatesModel.UserAggregate
{
    public class User : BaseEntity
    {
        public Guid? CartId { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? PaymentDetailsId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public Cart? Cart { get; set; }
        public Address? Address { get; set; }
        public PaymentDetails? PaymentDetails { get; set; }

        public User() { }
    }
}