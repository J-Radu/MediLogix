namespace MediLogix.Application.Commands.Description;

public sealed class CreateDescriptionCommand : IRequest<DescriptionDto>
{
    public string DeviceName { get; set; }
    public string DeviceDescription { get; set; }
    public string DeviceNumber { get; set; }
    public string InventoryNumber { get; set; }
} 