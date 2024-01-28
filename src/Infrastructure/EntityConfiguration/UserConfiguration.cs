namespace Infrastructure.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Username);
            builder.Property(p => p.Password);

            builder.Property(p => p.FirstName);
            builder.Property(p => p.LastName);
            builder.Property(p => p.PhoneNumber);

            builder.Property(p => p.Cart);
            builder.Property(p => p.Address);
            builder.Property(p => p.PaymentDetails);
        }
    }
}
