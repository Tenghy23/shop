namespace Infrastructure.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.CategoryName).IsRequired();

            builder.Property(p => p.Description);
        }
    }
}