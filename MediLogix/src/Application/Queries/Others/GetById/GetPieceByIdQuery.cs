namespace MediLogix.Application.Queries.Others.GetById;

public class GetPieceByIdQuery : IRequest<PieceDto>
{
    public Guid Id { get; set; }
}
