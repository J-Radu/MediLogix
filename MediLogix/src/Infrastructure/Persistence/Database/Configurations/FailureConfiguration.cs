namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class FailureConfiguration : IEntityTypeConfiguration<Failure>
{
    public void Configure(EntityTypeBuilder<Failure> builder)
    {
        builder
            .HasKey(f => f.Id);
        builder
            .HasOne(e => e.Device)
            .WithMany(e => e.Failures);
        builder
            .Property(f => f.FailureType)
            .HasMaxLength(30);
        builder
            .Property(f => f.FailureDescription)
            .HasMaxLength(150);

    }
}