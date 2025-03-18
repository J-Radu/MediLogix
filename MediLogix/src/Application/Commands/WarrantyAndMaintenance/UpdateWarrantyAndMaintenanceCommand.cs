namespace MediLogix.Application.Commands.WarrantyAndMaintenance;

public sealed class UpdateWarrantyAndMaintenanceCommand : EntityBase, IRequest<WarrantyAndMaintenanceDto>
{
    public string ContractNumber { get; set; }
    public string MaintenanceContract { get; set; }
    public string Provider { get; set; }
    public string ServiceAgent { get; set; }
    public DateOnly ExpirationDate { get; set; }
} 