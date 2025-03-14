namespace MediLogix.Application.Queries.Others.GetById;

public class GetDescriptionByIdQuery : IRequest<DescriptionDto>
{
    public Guid Id { get; set; }
} 