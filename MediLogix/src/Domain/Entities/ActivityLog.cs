namespace MediLogix.Domain.Entities;

public class ActivityLog
{
    public int Id { get; init; }
    public string UserId { get; init; }
    public string UserFirstName { get; init; }
    public string UserLastName { get; init; }
    public string Action { get; init; }
    public string Route { get; init; }
    public string IpAddress { get; init; }
    public DateTime Timestamp { get; init; }
} 