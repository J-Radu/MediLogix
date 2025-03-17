namespace MediLogix.Application.DTOs;

public sealed class FailureDto : EntityBase
{
    public Guid DeviceId { get; set; }
    public string? FailureType { get; set; }
    public string? FailureDescription { get; set; }
}