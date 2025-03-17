namespace MediLogix.Application.Handlers.Queries.Others.GetAll;

public class GetAllOperatingTermsQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllOperatingTermsQuery, List<OperatingTermsDto>>
{
    public async Task<List<OperatingTermsDto>> Handle(GetAllOperatingTermsQuery request, CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var operatingTerms = await context.OperatingTerms
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return operatingTerms.Select(ot => new OperatingTermsDto
        {
            Id = ot.Id,
            ProductionDate = ot.ProductionDate,
            DeliveryDate = ot.DeliveryDate,
            InstallationDate = ot.InstallationDate,
            GuaranteeExpirationDate = ot.GuaranteeExpirationDate,
            ExploitationTime = ot.ExploitationTime
        }).ToList();
    }
} 