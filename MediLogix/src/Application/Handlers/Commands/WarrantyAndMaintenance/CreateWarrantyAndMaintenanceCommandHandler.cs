namespace MediLogix.Application.Handlers.Commands.WarrantyAndMaintenance;

public sealed class CreateWarrantyAndMaintenanceCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<CreateWarrantyAndMaintenanceCommand, WarrantyAndMaintenanceDto>
{
    public async Task<WarrantyAndMaintenanceDto> Handle(CreateWarrantyAndMaintenanceCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var warrantyAndMaintenance = new Domain.Entities.WarrantyAndMaintenance
        {
            Id = request.Id,
            ContractNumber = request.ContractNumber,
            MaintenanceContract = request.MaintenanceContract,
            Provider = request.Provider,
            ServiceAgent = request.ServiceAgent,
            ExpirationDate = request.ExpirationDate
        };

        await context.WarrantyAndMaintenances.AddAsync(warrantyAndMaintenance, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<WarrantyAndMaintenanceDto>(warrantyAndMaintenance);
    }
} 