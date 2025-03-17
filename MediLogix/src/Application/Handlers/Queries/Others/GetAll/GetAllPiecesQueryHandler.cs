namespace MediLogix.Application.Handlers.Queries.Others.GetAll;

public class GetAllPiecesQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllPiecesQuery, List<PieceDto>>
{
    public async Task<List<PieceDto>> Handle(GetAllPiecesQuery request, CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
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