namespace MediLogix.Application.Handlers.Commands.OperatingTerms;

public sealed class DeleteOperatingTermsByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteOperatingTermsByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeleteOperatingTermsByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.OperatingTerms
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 