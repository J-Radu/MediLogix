namespace MediLogix.Domain.Entities;

public class Failure : EntityBase
{
    public Guid DeviceId { get; set; }
    public string? FailureType { get; set; }
    public string? FailureDescription { get; set; }
    public virtual Device? Device { get; set; }
}