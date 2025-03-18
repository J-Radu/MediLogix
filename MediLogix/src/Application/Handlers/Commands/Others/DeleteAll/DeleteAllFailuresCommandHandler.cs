namespace MediLogix.Application.Handlers.Commands.Others.DeleteAll;

public sealed class DeleteAllFailuresCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllFailuresCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllFailuresCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Failures.ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 