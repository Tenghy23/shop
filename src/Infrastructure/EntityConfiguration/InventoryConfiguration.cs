namespace Infrastructure.EntityConfiguration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Product);
            builder.Property(p => p.StockRemaining);
        }
    }
}