namespace MediLogix.Application.Handlers.Commands.CurrentLocation;

public sealed class DeleteAllCurrentLocationsCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllCurrentLocationsCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllCurrentLocationsCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.CurrentLocations.ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 