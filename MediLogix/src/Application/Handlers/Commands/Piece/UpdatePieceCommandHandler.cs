namespace MediLogix.Application.Handlers.Commands.Piece;

public sealed class UpdatePieceCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<UpdatePieceCommand, PieceDto>
{
    public async Task<PieceDto> Handle(UpdatePieceCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var piece = await context.Pieces.FindAsync([request.Id], cancellationToken);
        
        if (piece == null)
            throw new Exception("The piece does not exist");

        piece.DeviceId = request.DeviceId;
        piece.Name = request.Name;
        piece.Price = request.Price;
        piece.AcquisitionDate = request.AcquisitionDate;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<PieceDto>(piece);
    }
} 