namespace MediLogix.Application.Handlers.Queries.Others.GetAll;

public class GetAllWarrantyAndMaintenancesQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllWarrantyAndMaintenancesQuery, List<WarrantyAndMaintenanceDto>>
{
    public async Task<List<WarrantyAndMaintenanceDto>> Handle(GetAllWarrantyAndMaintenancesQuery request, CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var warrantyAndMaintenances = await context.WarrantyAndMaintenances
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return warrantyAndMaintenances.Select(wm => new WarrantyAndMaintenanceDto
        {
            Id = wm.Id,
            ContractNumber = wm.ContractNumber,
            MaintenanceContract = wm.MaintenanceContract,
            Provider = wm.Provider,
            ServiceAgent = wm.ServiceAgent,
            ExpirationDate = wm.ExpirationDate
        }).ToList();
    }
} 