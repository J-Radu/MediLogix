namespace MediLogix.Application.Handlers.Commands.Description;

public sealed class DeleteDescriptionByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteDescriptionByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeleteDescriptionByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Descriptions
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 