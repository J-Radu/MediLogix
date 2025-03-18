namespace MediLogix.Application.Commands.Others.Create;

public sealed class CreateWarrantyAndMaintenanceCommand : IRequest<WarrantyAndMaintenanceDto>
{
    public string ContractNumber { get; set; }
    public string MaintenanceContract { get; set; }
    public string Provider { get; set; }
    public string ServiceAgent { get; set; }
    public DateOnly ExpirationDate { get; set; }
} 