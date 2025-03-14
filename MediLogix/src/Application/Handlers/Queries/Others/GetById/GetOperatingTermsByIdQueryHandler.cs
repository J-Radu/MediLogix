namespace MediLogix.Application.Handlers.Queries.Others.GetById;

public class GetOperatingTermsByIdQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetOperatingTermsByIdQuery, OperatingTermsDto>
{
    public async Task<OperatingTermsDto> Handle(GetOperatingTermsByIdQuery request, CancellationToken cancellationToken)
    {
        var operatingTerms = await context.OperatingTerms
            .AsNoTracking()
            .FirstOrDefaultAsync(ot => ot.Id == request.Id, cancellationToken);

        if (operatingTerms == null)
        {
            return null;
        }

        return new OperatingTermsDto
        {
            Id = operatingTerms.Id,
            ProductionDate = operatingTerms.ProductionDate,
            DeliveryDate = operatingTerms.DeliveryDate,
            InstallationDate = operatingTerms.InstallationDate,
            GuaranteeExpirationDate = operatingTerms.GuaranteeExpirationDate,
            ExploitationTime = operatingTerms.ExploitationTime
        };
    }
} 