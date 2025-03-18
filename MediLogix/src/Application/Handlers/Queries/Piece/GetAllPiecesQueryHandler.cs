using MediLogix.Application.Queries.Piece;

namespace MediLogix.Application.Handlers.Queries.Piece;

public sealed class GetAllPiecesQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllPiecesQuery, List<PieceDto>>
{
    public async Task<List<PieceDto>> Handle(GetAllPiecesQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var pieces = await context.Pieces
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return pieces.Select(p => new PieceDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            AcquisitionDate = p.AcquisitionDate
        }).ToList();
    }
} 