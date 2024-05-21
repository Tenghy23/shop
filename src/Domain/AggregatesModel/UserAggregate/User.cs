namespace Domain.AggregatesModel.UserAggregate
{
    public class User : IdentityUser, IBaseEntity
    {
        public Guid? CartId { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? PaymentDetailsId { get; set; }
        public string FirstName { get; set; } = "default";
        public string LastName { get; set; } = "default";
        public Cart? Cart { get; set; }
        public Address? Address { get; set; }
        public PaymentDetails? PaymentDetails { get; set; }

        public User() { }
    }
}