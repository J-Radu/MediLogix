namespace MediLogix.Application.Queries.Others.GetById;

public class GetFailureByIdQuery : IRequest<FailureDto>
{
    public Guid Id { get; set; }
}