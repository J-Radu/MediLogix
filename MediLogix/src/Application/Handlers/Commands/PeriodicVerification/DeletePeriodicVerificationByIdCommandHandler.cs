namespace MediLogix.Application.Handlers.Commands.PeriodicVerification;

public sealed class DeletePeriodicVerificationByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeletePeriodicVerificationByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeletePeriodicVerificationByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.PeriodicVerifications
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 