namespace MediLogix.Application.Handlers.Commands.MetrologyReport;

public sealed class DeleteMetrologyReportByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteMetrologyReportByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeleteMetrologyReportByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.MetrologyReports
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 