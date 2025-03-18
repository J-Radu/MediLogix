namespace MediLogix.Application.Handlers.Commands.Others.DeleteById;

public sealed class DeleteFailureByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteFailureByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeleteFailureByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Failures
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 