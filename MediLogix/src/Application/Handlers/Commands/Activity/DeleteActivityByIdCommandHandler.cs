namespace MediLogix.Application.Handlers.Commands.Activity;

public sealed class DeleteActivityByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteActivityByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeleteActivityByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var activity = await context.Activities
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (activity == null)
            throw new Exception($"Activity with Id {request.Id} does not exist");

        context.Activities.Remove(activity);
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
} 