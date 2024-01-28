namespace Infrastructure.EntityConfiguration
{
    public class PaymentDetailsConfiguration : IEntityTypeConfiguration<PaymentDetails>
    {
        public void Configure(EntityTypeBuilder<PaymentDetails> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount);
            builder.Property(p => p.Provider);
            builder.Property(p => p.Status);
        }
    }
}
