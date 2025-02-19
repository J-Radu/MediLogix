namespace MediLogix.Domain.Entities;

public class WarrantyAndMaintenance : EntityBase
{
    public string ContractNumber { get; set; }
    public string MaintenanceContract { get; set; }
    public string Provider { get; set; }
    public string ServiceAgent { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public virtual Device Device { get; set; }
}