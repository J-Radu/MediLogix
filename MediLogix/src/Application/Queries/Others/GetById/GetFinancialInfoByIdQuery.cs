namespace MediLogix.Application.Queries.Others.GetById;

public class GetFinancialInfoByIdQuery : IRequest<FinancialInfoDto>
{
    public Guid Id { get; set; }
} 