namespace MediLogix.Application.Queries.Others.GetById;

public class GetMetrologyReportByIdQuery : IRequest<MetrologyReportDto>
{
    public Guid Id { get; set; }
} 