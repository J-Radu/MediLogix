namespace MediLogix.Application.Commands.Others.Create;

public abstract class CreateCurrentLocationCommand : IRequest<CurrentLocationDto>
{
    public string IMS { get; set; }
    public string Department { get; set; }
    public string Localization { get; set; }
    public string Status { get; set; }
} 