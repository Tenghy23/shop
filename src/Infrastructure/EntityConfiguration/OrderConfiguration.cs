namespace Infrastructure.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.UserId);
            builder.Property(p => p.Total);

            builder.Property(p => p.PaymentDetails);
            builder.Property(p => p.OrderDetailsList);
        }
    }
}