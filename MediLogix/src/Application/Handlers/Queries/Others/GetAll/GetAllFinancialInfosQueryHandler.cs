namespace MediLogix.Application.Handlers.Queries.Others.GetAll;

public class GetAllFinancialInfosQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllFinancialInfosQuery, List<FinancialInfoDto>>
{
    public async Task<List<FinancialInfoDto>> Handle(GetAllFinancialInfosQuery request, CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
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