namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class PeriodicVerificationConfiguration : IEntityTypeConfiguration<PeriodicVerification>
{
    public void Configure(EntityTypeBuilder<PeriodicVerification> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .Property(e => e.IsSubject)
            .IsRequired();
        builder
            .Property(e => e.VerificationPeriodicityMonths)
            .IsRequired();
        builder
            .Property(e => e.CertificateNumber)
            .IsRequired()
            .HasMaxLength(40);
      builder
            .Property(e => e.LastVerificationDate)
            .IsRequired();
        builder
            .Property(e => e.IssueDate)
            .IsRequired();
    }
}