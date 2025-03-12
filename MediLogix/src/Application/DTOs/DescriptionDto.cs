namespace MediLogix.Application.DTOs;

public class DescriptionDto : EntityBase
{
    public string DeviceName { get; set; }
    public string DeviceDescription { get; set; }
    public string DeviceNumber { get; set; }
    public string InventoryNumber { get; set; }
}