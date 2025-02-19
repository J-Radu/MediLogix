namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class DescriptionConfiguration : IEntityTypeConfiguration<Description>
{
    public void Configure(EntityTypeBuilder<Description> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .Property(e => e.DeviceName)
            .IsRequired()
            .HasMaxLength(30);
        builder
            .Property(e => e.DeviceDescription)
            .IsRequired()
            .HasMaxLength(70);
        builder
            .Property(e => e.DeviceNumber)
            .IsRequired()
            .HasMaxLength(30);
        builder
            .Property(e => e.InventoryNumber)
            .IsRequired()
            .HasMaxLength(30);
    }
}