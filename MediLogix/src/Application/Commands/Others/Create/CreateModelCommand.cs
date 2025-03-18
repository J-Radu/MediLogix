namespace MediLogix.Application.Commands.Others.Create;

public sealed class CreateModelCommand : IRequest<ModelDto>
{
    public string DmModel { get; set; }
    public string GMDN { get; set; }
    public string Manufacturer { get; set; }
    public string Country { get; set; }
} 