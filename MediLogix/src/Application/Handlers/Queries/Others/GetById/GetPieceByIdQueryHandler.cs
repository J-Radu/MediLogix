namespace MediLogix.Application.Handlers.Queries.Others.GetById;

public class GetPieceByIdQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetPieceByIdQuery, PieceDto>
{
    public async Task<PieceDto> Handle(GetPieceByIdQuery request, CancellationToken cancellationToken)
    {
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