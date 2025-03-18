namespace MediLogix.Application.Handlers.Commands.Others.DeleteById;

public sealed class DeleteWarrantyAndMaintenanceByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteWarrantyAndMaintenanceByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeleteWarrantyAndMaintenanceByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.WarrantyAndMaintenances
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 