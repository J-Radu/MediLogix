namespace MediLogix.Application.Handlers.Commands.Piece;

public sealed class DeleteAllPiecesCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllPiecesCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllPiecesCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Pieces.ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 