namespace Infrastructure.EntityConfiguration
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Name);
            builder.Property(p => p.Description);

        }
    }
}
