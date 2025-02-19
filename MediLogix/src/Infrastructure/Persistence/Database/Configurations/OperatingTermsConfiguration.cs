namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class OperatingTermsConfiguration : IEntityTypeConfiguration<OperatingTerms>
{
    public void Configure(EntityTypeBuilder<OperatingTerms> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .Property(e => e.ProductionDate)
            .IsRequired();
        builder
            .Property(e => e.DeliveryDate)
            .IsRequired();
        builder
            .Property(e => e.InstallationDate)
            .IsRequired();
        builder
            .Property(e => e.GuaranteeExpirationDate)
            .IsRequired();
        builder
            .Property(e => e.ExploitationTime)
            .IsRequired();
    }
}