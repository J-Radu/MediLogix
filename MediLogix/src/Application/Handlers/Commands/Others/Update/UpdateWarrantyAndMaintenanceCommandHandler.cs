namespace MediLogix.Application.Handlers.Commands.Others.Update;

public sealed class UpdateWarrantyAndMaintenanceCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<UpdateWarrantyAndMaintenanceCommand, WarrantyAndMaintenanceDto>
{
    public async Task<WarrantyAndMaintenanceDto> Handle(UpdateWarrantyAndMaintenanceCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var warrantyAndMaintenance = await context.WarrantyAndMaintenances.FindAsync([request.Id], cancellationToken);
        
        if (warrantyAndMaintenance == null)
            throw new Exception("The warranty and maintenance does not exist.");

        warrantyAndMaintenance.ContractNumber = request.ContractNumber;
        warrantyAndMaintenance.MaintenanceContract = request.MaintenanceContract;
        warrantyAndMaintenance.Provider = request.Provider;
        warrantyAndMaintenance.ServiceAgent = request.ServiceAgent;
        warrantyAndMaintenance.ExpirationDate = request.ExpirationDate;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<WarrantyAndMaintenanceDto>(warrantyAndMaintenance);
    }
} 