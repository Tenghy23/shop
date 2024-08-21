namespace Infrastructure.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.FirstName);
            builder.Property(p => p.LastName);
            builder.Property(p => p.PhoneNumber);

            builder.HasOne(u => u.Cart)
                        .WithOne()
                        .HasForeignKey<User>(u => u.CartId);

            builder.HasOne(u => u.Address)
                        .WithOne()
                        .HasForeignKey<User>(u => u.AddressId);

            builder.HasOne(u => u.PaymentDetails)
                        .WithOne()
                        .HasForeignKey<User>(u => u.PaymentDetailsId);

            builder.ToTable("Users", "identity");
        }
    }
}
    