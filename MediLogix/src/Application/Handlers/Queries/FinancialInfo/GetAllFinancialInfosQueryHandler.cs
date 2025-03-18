using MediLogix.Application.Queries.FinancialInfo;

namespace MediLogix.Application.Handlers.Queries.FinancialInfo;

public sealed class GetAllFinancialInfosQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllFinancialInfosQuery, List<FinancialInfoDto>>
{
    public async Task<List<FinancialInfoDto>> Handle(GetAllFinancialInfosQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
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