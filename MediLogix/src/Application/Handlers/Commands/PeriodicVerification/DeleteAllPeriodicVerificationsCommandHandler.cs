namespace MediLogix.Application.Handlers.Commands.PeriodicVerification;

public sealed class DeleteAllPeriodicVerificationsCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllPeriodicVerificationsCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllPeriodicVerificationsCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.PeriodicVerifications.ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 