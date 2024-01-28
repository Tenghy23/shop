namespace Infrastructure.EntityConfiguration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.ProductId); // dont want to set navigation property so as to not load all the related stuff 
            builder.Property(p => p.StockRemaining);
        }
    }
}