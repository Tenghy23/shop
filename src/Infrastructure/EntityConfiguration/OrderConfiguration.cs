namespace Infrastructure.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.UserId);
            builder.Property(p => p.Total);

            builder.HasMany(p => p.OrderDetailsList);

            builder.HasOne(p => p.PaymentDetails);
        }
    }
}