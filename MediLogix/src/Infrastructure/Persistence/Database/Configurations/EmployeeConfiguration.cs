namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(15);
        builder
            .Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(15);
        builder
            .Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .Property(e => e.PhoneNumber)
            .IsRequired()
            .HasMaxLength(10);
        builder
            .Property(e => e.Address)
            .IsRequired()
            .HasMaxLength(30);
        builder
            .Property(e => e.City)
            .IsRequired()
            .HasMaxLength(15);
        builder
            .Property(e => e.JobName)
            .IsRequired()
            .HasMaxLength(20);
    }
}