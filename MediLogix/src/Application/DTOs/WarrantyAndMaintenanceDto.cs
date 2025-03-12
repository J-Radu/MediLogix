namespace MediLogix.Application.DTOs;

public class WarrantyAndMaintenanceDto : EntityBase
{
    public string ContractNumber { get; set; }
    public string MaintenanceContract { get; set; }
    public string Provider { get; set; }
    public string ServiceAgent { get; set; }
    public DateOnly ExpirationDate { get; set; }
}