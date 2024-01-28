namespace Infrastructure.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CategoryName).IsRequired();
            builder.Property(p => p.Description);
        }
    }
}