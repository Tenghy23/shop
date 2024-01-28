using Domain.AggregatesModel.CartAggregate;
using Domain.AggregatesModel.CommonAggregate;
using Domain.AggregatesModel.PaymentDetailsAggregate;
using Domain.AggregatesModel.AddressAggregate;

namespace Domain.AggregatesModel.UserAggregate
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public Cart? Cart { get; set; }
        public Address? Address { get; set; }
        public PaymentDetails? PaymentDetails { get; set; }

        public User(string username, string password, string firstName, string lastName,
            int phoneNumber, Cart? cart, Address? address, PaymentDetails? paymentDetails)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Cart = cart;
            Address = address;
            PaymentDetails = paymentDetails;
        }
    }
}