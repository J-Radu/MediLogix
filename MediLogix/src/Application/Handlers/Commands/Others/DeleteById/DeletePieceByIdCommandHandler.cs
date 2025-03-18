namespace MediLogix.Application.Handlers.Commands.Others.DeleteById;

public sealed class DeletePieceByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeletePieceByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeletePieceByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Pieces
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 