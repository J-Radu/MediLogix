namespace MediLogix.Application.Handlers.Commands.Device;

public sealed class DeleteAllDevicesCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllDevicesCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllDevicesCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Devices
            .ExecuteDeleteAsync(cancellationToken);

        return Unit.Value;
    }
} 