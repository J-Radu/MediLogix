namespace MediLogix.Domain.Repositories;

public interface IActivityLogRepository
{
    Task<int> AddLogAsync(ActivityLog? log);
    Task<IEnumerable<ActivityLog>> GetLogsAsync(DateTime? fromDate = null, DateTime? toDate = null, string userId = null);
    Task<ActivityLog?> GetLogByIdAsync(int id);
}