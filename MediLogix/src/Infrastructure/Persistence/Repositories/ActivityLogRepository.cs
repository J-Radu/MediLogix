namespace MediLogix.Infrastructure.Persistence.Repositories;

public class ActivityLogRepository(IDbContextFactory<MediLogixDbContext> contextFactory) : IActivityLogRepository
{
    public async Task<int> AddLogAsync(ActivityLog? log)
    {
        await using var dbContext = await contextFactory.CreateDbContextAsync();
        dbContext.ActivityLogs.Add(log);
        await dbContext.SaveChangesAsync();
        return log.Id;
    }

    public async Task<IEnumerable<ActivityLog>> GetLogsAsync(DateTime? fromDate = null, DateTime? toDate = null, string userId = null)
    {
        await using var dbContext = await contextFactory.CreateDbContextAsync();
        var query = dbContext.ActivityLogs.AsQueryable();

        if (fromDate.HasValue)
            query = query.Where(l => l.Timestamp >= fromDate.Value);

        if (toDate.HasValue)
            query = query.Where(l => l.Timestamp <= toDate.Value);

        if (!string.IsNullOrEmpty(userId))
            query = query.Where(l => l.UserId == userId);

        return await query.OrderByDescending(l => l.Timestamp).ToListAsync();
    }

    public async Task<ActivityLog?> GetLogByIdAsync(int id)
    {
        await using var dbContext = await contextFactory.CreateDbContextAsync();
        return await dbContext.ActivityLogs.FindAsync(id);
    }
}