namespace MediLogix.Application.Queries.Others.GetById;

public class GetCurrentLocationByIdQuery : IRequest<CurrentLocationDto>
{
    public Guid Id { get; set; }
} 