namespace MediLogix.Application.Handlers.Commands.Device;

public sealed class DeleteDeviceByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteDeviceByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeleteDeviceByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var device = await context.Devices
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (device == null)
            throw new Exception("Device not found");

        context.Devices.Remove(device);
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
} 