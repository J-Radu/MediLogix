namespace MediLogix.Domain.Entities;

public class Description : EntityBase
{
    public string DeviceName { get; set; }
    public string DeviceDescription { get; set; }
    public string DeviceNumber { get; set; }
    public string InventoryNumber { get; set; }
    public virtual Device Device { get; set; }
}