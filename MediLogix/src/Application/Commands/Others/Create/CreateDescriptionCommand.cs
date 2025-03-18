namespace MediLogix.Application.Commands.Others.Create;

public sealed class CreateDescriptionCommand : IRequest<DescriptionDto>
{
    public string DeviceName { get; set; }
    public string DeviceDescription { get; set; }
    public string DeviceNumber { get; set; }
    public string InventoryNumber { get; set; }
} 