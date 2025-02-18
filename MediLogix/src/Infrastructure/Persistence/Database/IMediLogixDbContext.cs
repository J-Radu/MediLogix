namespace MediLogix.Infrastructure.Persistence.Database;

public interface IMediLogixDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}