namespace Infrastructure.EntityConfiguration
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.ProductId);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Percentage);
            builder.Property(p => p.FixedValue);

            builder.Property(p => p.Active);
        }
    }
}