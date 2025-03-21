namespace MediLogix.Infrastructure.Persistence.Database;

public interface IMediLogixDbContext
{
    DbSet<Activity> Activities { get; set; }
    DbSet<CurrentLocation> CurrentLocations { get; set; }
    DbSet<Description> Descriptions { get; set; }
    DbSet<Device> Devices { get; set; }
    DbSet<Failure> Failures { get; set; }
    DbSet<Employee> Employees { get; set; }
    DbSet<FinancialInfo> FinancialInfos { get; set; }
    DbSet<Model> Models { get; set; }
    DbSet<OperatingTerms> OperatingTerms { get; set; }
    DbSet<PeriodicVerification> PeriodicVerifications { get; set; }
    DbSet<Piece> Pieces { get; set; }
    DbSet<WarrantyAndMaintenance> WarrantyAndMaintenances { get; set; }
    DbSet<MetrologyReport> MetrologyReports { get; set; }
    DbSet<ActivityLog> ActivityLogs { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}