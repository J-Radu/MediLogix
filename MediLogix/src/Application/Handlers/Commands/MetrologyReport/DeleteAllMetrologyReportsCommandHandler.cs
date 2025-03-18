namespace MediLogix.Application.Handlers.Commands.MetrologyReport;

public sealed class DeleteAllMetrologyReportsCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllMetrologyReportsCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllMetrologyReportsCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.MetrologyReports.ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 