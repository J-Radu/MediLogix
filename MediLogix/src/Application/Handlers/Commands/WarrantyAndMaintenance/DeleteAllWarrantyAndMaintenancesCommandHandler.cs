namespace MediLogix.Application.Handlers.Commands.WarrantyAndMaintenance;

public sealed class DeleteAllWarrantyAndMaintenancesCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllWarrantyAndMaintenancesCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllWarrantyAndMaintenancesCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.WarrantyAndMaintenances.ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 