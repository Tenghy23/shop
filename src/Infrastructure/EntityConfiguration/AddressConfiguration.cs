namespace Infrastructure.EntityConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.UserId).IsRequired();

            builder.Property(p => p.AddressLine1);
            builder.Property(p => p.AddressLine2);
            builder.Property(p => p.City);
            builder.Property(p => p.PostalCode);

            builder.Property(p => p.Country);
            builder.Property(p => p.MobileNumber);
            builder.Property(p => p.Email);
        }
    }
}