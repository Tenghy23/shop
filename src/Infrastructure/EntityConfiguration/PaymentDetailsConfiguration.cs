namespace Infrastructure.EntityConfiguration
{
    public class PaymentDetailsConfiguration : IEntityTypeConfiguration<PaymentDetails>
    {
        public void Configure(EntityTypeBuilder<PaymentDetails> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.OrderId).IsRequired();

            builder.Property(p => p.Amount);
            builder.Property(p => p.Provider);
            builder.Property(p => p.Status);
        }
    }
}
