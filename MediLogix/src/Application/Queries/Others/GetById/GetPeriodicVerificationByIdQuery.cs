namespace MediLogix.Application.Queries.Others.GetById;

public class GetPeriodicVerificationByIdQuery : IRequest<PeriodicVerificationDto>
{
    public Guid Id { get; set; }
} 