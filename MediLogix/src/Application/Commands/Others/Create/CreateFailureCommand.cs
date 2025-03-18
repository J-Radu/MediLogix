namespace MediLogix.Application.Commands.Others.Create;

public sealed class CreateFailureCommand : IRequest<FailureDto>
{
    public Guid DeviceId { get; set; }
    public string? FailureType { get; set; }
    public string? FailureDescription { get; set; }
} 