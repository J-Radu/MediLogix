namespace MediLogix.Application.Handlers.Commands.CurrentLocation;

public sealed class DeleteCurrentLocationByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteCurrentLocationByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCurrentLocationByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.CurrentLocations
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 