namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .Property(e => e.DmModel)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .Property(e => e.GMDN)
            .IsRequired()
            .HasMaxLength(50);
        builder.
            Property(e => e.Manufacturer)
            .IsRequired()
            .HasMaxLength(50);
        builder.
            Property(e => e.Country)
            .IsRequired()
            .HasMaxLength(20);
    }
}