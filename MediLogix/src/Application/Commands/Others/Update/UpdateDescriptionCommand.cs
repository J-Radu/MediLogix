namespace MediLogix.Application.Commands.Others.Update;

public abstract class UpdateDescriptionCommand : EntityBase, IRequest<DescriptionDto>
{
    public string DeviceName { get; set; }
    public string DeviceDescription { get; set; }
    public string DeviceNumber { get; set; }
    public string InventoryNumber { get; set; }
} 