using MediLogix.Application.Queries.Piece;

namespace MediLogix.Application.Handlers.Queries.Piece;

public sealed class GetPieceByIdQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetPieceByIdQuery, PieceDto>
{
    public async Task<PieceDto> Handle(GetPieceByIdQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var piece = await context.Pieces
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (piece == null)
        {
            return null;
        }

        return new PieceDto
        {
            Id = piece.Id,
            DeviceId = piece.DeviceId,
            Name = piece.Name,
            Price = piece.Price,
            AcquisitionDate = piece.AcquisitionDate
        };
    }
}