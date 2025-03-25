namespace MediLogix.Domain.Entities;

public sealed class Description : EntityBase
{
    public string DeviceName { get; set; }
    public string DeviceDescription { get; set; }
    public string DeviceNumber { get; set; }
    public string InventoryNumber { get; set; }
    public Device? Device { get; set; }
}