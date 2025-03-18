namespace MediLogix.Application.Handlers.Commands.Others.Create;

public sealed class CreateOperatingTermsCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<CreateOperatingTermsCommand, OperatingTermsDto>
{
    public async Task<OperatingTermsDto> Handle(CreateOperatingTermsCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var operatingTerms = new OperatingTerms
        {
            ProductionDate = request.ProductionDate,
            DeliveryDate = request.DeliveryDate,
            InstallationDate = request.InstallationDate,
            GuaranteeExpirationDate = request.GuaranteeExpirationDate,
            ExploitationTime = request.ExploitationTime
        };

        await context.OperatingTerms.AddAsync(operatingTerms, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<OperatingTermsDto>(operatingTerms);
    }
} 