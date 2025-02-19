namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class PieceConfiguration : IEntityTypeConfiguration<Piece>
{
    public void Configure(EntityTypeBuilder<Piece> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .HasOne(e => e.Device)
            .WithMany(e => e.Pieces)
            .HasForeignKey(e => e.DeviceId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(30);
        builder
            .Property(e => e.Price)
            .IsRequired();
        builder
            .Property(e => e.AcquisitionDate)
            .IsRequired();
    }
}