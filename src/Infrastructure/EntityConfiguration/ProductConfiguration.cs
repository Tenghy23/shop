namespace Infrastructure.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /* this custom EF config allows us to config the entity to 
            however we want by utilising the builder */
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.InventoryId);

            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Quantity);
            builder.Property(p => p.Price);

            builder.HasMany(u => u.Discount);
        }
    }
}