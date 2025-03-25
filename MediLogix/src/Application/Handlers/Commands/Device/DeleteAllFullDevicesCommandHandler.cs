namespace MediLogix.Application.Handlers.Commands.Device;

public sealed class DeleteAllFullDevicesCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllFullDevicesCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllFullDevicesCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Devices
            .ExecuteDeleteAsync(cancellationToken);

        return Unit.Value;
    }
} 