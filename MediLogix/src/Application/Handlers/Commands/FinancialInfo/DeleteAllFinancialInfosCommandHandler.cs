namespace MediLogix.Application.Handlers.Commands.FinancialInfo;

public sealed class DeleteAllFinancialInfosCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllFinancialInfosCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllFinancialInfosCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.FinancialInfos.ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 