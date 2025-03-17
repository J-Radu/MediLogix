namespace MediLogix.Infrastructure.Persistence.Database.Configurations;

public class MetrologyReportConfiguration : IEntityTypeConfiguration<MetrologyReport>
{
    public void Configure(EntityTypeBuilder<MetrologyReport> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.ReportNumber)
            .HasMaxLength(50)
            .IsRequired();
        builder
            .Property(x => x.IssuingAuthority)
            .HasMaxLength(100)
            .IsRequired();
        builder
            .Property(x => x.Findings)
            .HasMaxLength(2000);
        builder.Property(x => x.Recommendations)
            .HasMaxLength(2000);

        builder
            .Property(x => x.DocumentName)
            .HasMaxLength(255)
            .IsRequired();
        builder
            .Property(x => x.DocumentType)
            .HasMaxLength(10)
            .IsRequired();
        builder
            .Property(e => e.DocumentData)
            .HasColumnType("varbinary(max) FILESTREAM");
        builder
            .Property(x => x.IssueDate)
            .IsRequired();
        builder.Property(x => x.ExpirationDate)
            .IsRequired();
        builder
            .Property(x => x.UploadDate)
            .IsRequired();
        builder
            .Property(x => x.IsApproved)
            .IsRequired();
        builder
            .Property(x => x.DocumentSize)
            .IsRequired();
        builder
            .HasOne(x => x.Device)
            .WithMany(d => d.MetrologyReports)
            .HasForeignKey(x => x.DeviceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 