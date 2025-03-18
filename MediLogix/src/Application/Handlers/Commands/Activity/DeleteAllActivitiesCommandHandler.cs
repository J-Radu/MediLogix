namespace MediLogix.Application.Handlers.Commands.Activity;

public sealed class DeleteAllActivitiesCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllActivitiesCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllActivitiesCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Activities
            .ExecuteDeleteAsync(cancellationToken);

        return Unit.Value;
    }
} 