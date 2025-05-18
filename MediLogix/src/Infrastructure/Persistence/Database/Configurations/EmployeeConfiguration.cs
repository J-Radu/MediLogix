namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .HasOne(e => e.User)
            .WithOne(u => u.Employee)
            .HasForeignKey<Employee>(e => e.UserId);
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
            .HasMaxLength(50);
        builder
            .Property(e => e.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);
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