namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class CurrentLocationConfiguration : IEntityTypeConfiguration<CurrentLocation>
{
    public void Configure(EntityTypeBuilder<CurrentLocation> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .Property(e => e.IMS)
            .IsRequired()
            .HasMaxLength(30);
        builder
            .Property(e => e.Department)
            .IsRequired()
            .HasMaxLength(30);
        builder
            .Property(e => e.Localization)
            .IsRequired()
            .HasMaxLength(30);
        builder
            .Property(e => e.Status)
            .IsRequired()
            .HasMaxLength(10);
        
    }
}