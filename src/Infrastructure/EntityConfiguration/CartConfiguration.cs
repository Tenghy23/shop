namespace Infrastructure.EntityConfiguration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.UserId).IsRequired();

            builder.Property(p => p.ProductList);
        }
    }
}