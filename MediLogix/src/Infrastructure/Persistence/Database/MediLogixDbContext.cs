namespace MediLogix.Infrastructure.Persistence.Database;

public sealed class MediLogixDbContext : IdentityDbContext, IMediLogixDbContext
{
    public MediLogixDbContext(DbContextOptions<MediLogixDbContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    /*public DbSet<Course> Courses { get; set; }
    public DbSet<Domain.Entities.Module> Modules { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ContributorToCourse> ContributorToCourses { get; set; }
    public DbSet<EnrollmentToCourse> EnrollmentToCourses { get; set; }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.ApplyConfiguration(new CourseConfiguration());
        // modelBuilder.ApplyConfiguration(new ModuleConfiguration());

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}