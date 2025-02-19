namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .HasOne(e => e.Employee)
            .WithMany(e => e.Activities)
            .HasForeignKey(e => e.EmployeeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .Property(e => e.EventName)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .Property(e => e.Notes)
            .HasMaxLength(100);
        builder
            .Property(e => e.EventDate)
            .IsRequired();
    }
}