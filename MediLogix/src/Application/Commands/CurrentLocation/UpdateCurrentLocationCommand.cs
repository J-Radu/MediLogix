namespace MediLogix.Application.Commands.CurrentLocation;

public sealed class UpdateCurrentLocationCommand : EntityBase, IRequest<CurrentLocationDto>
{
    public string IMS { get; set; }
    public string Department { get; set; }
    public string Localization { get; set; }
    public string Status { get; set; }
} 