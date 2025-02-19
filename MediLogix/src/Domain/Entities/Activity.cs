namespace MediLogix.Domain.Entities;

public class Activity : EntityBase
{
    public Guid EmployeeId { get; set; }
    public DateOnly EventDate { get; set; }
    public string EventName { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsSuccessful { get; set; }
    public string? Notes { get; set; }
    public virtual Employee Employee { get; set; }
}