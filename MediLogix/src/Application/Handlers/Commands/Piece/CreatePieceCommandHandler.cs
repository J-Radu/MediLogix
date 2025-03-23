namespace MediLogix.Application.Handlers.Commands.Piece;

public sealed class CreatePieceCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<CreatePieceCommand, PieceDto>
{
    public async Task<PieceDto> Handle(CreatePieceCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var piece = new Domain.Entities.Piece
        {
            Id = request.Id,
            DeviceId = request.DeviceId,
            Name = request.Name,
            Price = request.Price,
            AcquisitionDate = request.AcquisitionDate
        };

        await context.Pieces.AddAsync(piece, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<PieceDto>(piece);
    }
} 