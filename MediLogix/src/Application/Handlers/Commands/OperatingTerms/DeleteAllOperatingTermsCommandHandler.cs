namespace MediLogix.Application.Handlers.Commands.OperatingTerms;

public sealed class DeleteAllOperatingTermsCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllOperatingTermsCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllOperatingTermsCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.OperatingTerms.ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 