namespace MediLogix.Application.Queries.Others.GetById;

public class GetOperatingTermsByIdQuery : IRequest<OperatingTermsDto>
{
    public Guid Id { get; set; }
} 