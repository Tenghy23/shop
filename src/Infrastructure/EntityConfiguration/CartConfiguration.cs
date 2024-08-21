namespace Infrastructure.EntityConfiguration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.ProductList);
        }
    }
}