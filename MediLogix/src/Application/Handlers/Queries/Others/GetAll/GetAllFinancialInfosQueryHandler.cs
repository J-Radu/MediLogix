namespace MediLogix.Application.Handlers.Queries.Others.GetAll;

public class GetAllFinancialInfosQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetAllFinancialInfosQuery, List<FinancialInfoDto>>
{
    public async Task<List<FinancialInfoDto>> Handle(GetAllFinancialInfosQuery request, CancellationToken cancellationToken)
    {
        var financialInfos = await context.FinancialInfos
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return financialInfos.Select(fi => new FinancialInfoDto
        {
            Id = fi.Id,
            AcquisitionPrice = fi.AcquisitionPrice,
            Currency = fi.Currency
        }).ToList();
    }
} 