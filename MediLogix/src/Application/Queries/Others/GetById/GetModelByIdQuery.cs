namespace MediLogix.Application.Queries.Others.GetById;

public class GetModelByIdQuery : IRequest<ModelDto>
{
    public Guid Id { get; set; }
} 