namespace MediLogix.Application.Handlers.Queries.Others.GetById;

public class GetFinancialInfoByIdQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetFinancialInfoByIdQuery, FinancialInfoDto>
{
    public async Task<FinancialInfoDto> Handle(GetFinancialInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var financialInfo = await context.FinancialInfos
            .AsNoTracking()
            .FirstOrDefaultAsync(fi => fi.Id == request.Id, cancellationToken);

        if (financialInfo == null)
        {
            return null;
        }

        return new FinancialInfoDto
        {
            Id = financialInfo.Id,
            AcquisitionPrice = financialInfo.AcquisitionPrice,
            Currency = financialInfo.Currency
        };
    }
} 