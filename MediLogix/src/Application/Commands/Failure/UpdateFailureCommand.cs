namespace MediLogix.Application.Commands.Failure;

public sealed class UpdateFailureCommand : EntityBase, IRequest<FailureDto>
{
    public Guid DeviceId { get; set; }
    public string? FailureType { get; set; }
    public string? FailureDescription { get; set; }
} 