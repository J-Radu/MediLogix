namespace MediLogix.Application.Handlers.Commands.Others.DeleteById;

public sealed class DeleteFinancialInfoByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteFinancialInfoByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeleteFinancialInfoByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.FinancialInfos
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 