namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .HasOne(e => e.CurrentLocation)
            .WithOne(e => e.Device)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(e => e.Description)
            .WithOne(e => e.Device)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(e => e.Employee)
            .WithMany(e => e.Devices)
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(e => e.FinancialInfo)
            .WithOne(e => e.Device)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(e => e.Model)
            .WithOne(e => e.Device)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(e => e.OperatingTerms)
            .WithOne(e => e.Device)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(e => e.PeriodicVerification)
            .WithOne(e => e.Device)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(e => e.WarrantyAndMaintenance)
            .WithOne(e => e.Device)
            .OnDelete(DeleteBehavior.Cascade);
    }
}