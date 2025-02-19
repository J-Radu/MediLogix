namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class FinancialInfoConfiguration : IEntityTypeConfiguration<FinancialInfo>
{
    public void Configure(EntityTypeBuilder<FinancialInfo> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .Property(e => e.Currency)
            .IsRequired()
            .HasMaxLength(20);
    }
}