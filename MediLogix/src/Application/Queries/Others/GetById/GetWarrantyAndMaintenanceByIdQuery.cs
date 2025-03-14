namespace MediLogix.Application.Queries.Others.GetById;

public class GetWarrantyAndMaintenanceByIdQuery : IRequest<WarrantyAndMaintenanceDto>
{
    public Guid Id { get; set; }
} 