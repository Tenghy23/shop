namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public Cart Cart { get; set; }
        public Address Address { get; set; }
        public PaymentDetails PaymentDetails { get; set; }

        public User() { }
    }
}