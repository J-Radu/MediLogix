namespace MediLogix.Application.Handlers.Commands.Others.DeleteAll;

public sealed class DeleteAllModelsCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllModelsCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllModelsCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Models.ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 