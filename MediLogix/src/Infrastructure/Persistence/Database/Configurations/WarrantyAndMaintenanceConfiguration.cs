namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class WarrantyAndMaintenanceConfiguration : IEntityTypeConfiguration<WarrantyAndMaintenance>
{
    public void Configure(EntityTypeBuilder<WarrantyAndMaintenance> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .Property(e => e.ContractNumber)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .Property(e => e.MaintenanceContract)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .Property(e => e.Provider)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .Property(e => e.ServiceAgent)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .Property(e => e.ExpirationDate)
            .IsRequired();
    }
}