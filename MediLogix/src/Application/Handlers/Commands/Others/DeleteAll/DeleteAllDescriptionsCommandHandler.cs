namespace MediLogix.Application.Handlers.Commands.Others.DeleteAll;

public sealed class DeleteAllDescriptionsCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllDescriptionsCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllDescriptionsCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Descriptions.ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 