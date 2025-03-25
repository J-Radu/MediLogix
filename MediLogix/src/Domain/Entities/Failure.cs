namespace MediLogix.Domain.Entities;

public sealed class Failure : EntityBase
{
    public Guid DeviceId { get; set; }
    public string? FailureType { get; set; }
    public string? FailureDescription { get; set; }
    public Device? Device { get; set; }
}