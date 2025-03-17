namespace MediLogix.Application.Handlers.Queries.Others.GetById;

public class GetWarrantyAndMaintenanceByIdQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetWarrantyAndMaintenanceByIdQuery, WarrantyAndMaintenanceDto>
{
    public async Task<WarrantyAndMaintenanceDto> Handle(GetWarrantyAndMaintenanceByIdQuery request, CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var warrantyAndMaintenance = await context.WarrantyAndMaintenances
            .AsNoTracking()
            .FirstOrDefaultAsync(wm => wm.Id == request.Id, cancellationToken);

        if (warrantyAndMaintenance == null)
        {
            return null;
        }

        return new WarrantyAndMaintenanceDto
        {
            Id = warrantyAndMaintenance.Id,
            ContractNumber = warrantyAndMaintenance.ContractNumber,
            MaintenanceContract = warrantyAndMaintenance.MaintenanceContract,
            Provider = warrantyAndMaintenance.Provider,
            ServiceAgent = warrantyAndMaintenance.ServiceAgent,
            ExpirationDate = warrantyAndMaintenance.ExpirationDate
        };
    }
} 