namespace MediLogix.Application.Commands.Model;

public sealed class UpdateModelCommand : EntityBase, IRequest<ModelDto>
{
    public string DmModel { get; set; }
    public string GMDN { get; set; }
    public string Manufacturer { get; set; }
    public string Country { get; set; }
} 