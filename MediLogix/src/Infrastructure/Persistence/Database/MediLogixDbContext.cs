namespace MediLogix.Infrastructure.Persistence.Database;

public sealed class MediLogixDbContext : IdentityDbContext, IMediLogixDbContext
{
    public MediLogixDbContext(DbContextOptions<MediLogixDbContext> options) : base(options)
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
    }
    
    public DbSet<Activity> Activities { get; set; }
    public DbSet<CurrentLocation> CurrentLocations { get; set; }
    public DbSet<Description> Descriptions { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<FinancialInfo> FinancialInfos { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<OperatingTerms> OperatingTerms { get; set; }
    public DbSet<PeriodicVerification> PeriodicVerifications { get; set; }
    public DbSet<Piece> Pieces { get; set; }
    public DbSet<WarrantyAndMaintenance> WarrantyAndMaintenances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}