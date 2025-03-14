namespace MediLogix.Application.Queries.Activity;

public class GetActivityByIdQuery : IRequest<ActivityDto>
{
    public Guid Id { get; set; }
} 