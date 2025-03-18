namespace MediLogix.Application.Commands.Others.Update;

public abstract class UpdateModelCommand : EntityBase, IRequest<ModelDto>
{
    public string DmModel { get; set; }
    public string GMDN { get; set; }
    public string Manufacturer { get; set; }
    public string Country { get; set; }
} 