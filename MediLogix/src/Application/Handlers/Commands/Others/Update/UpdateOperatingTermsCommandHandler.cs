namespace MediLogix.Application.Handlers.Commands.Others.Update;

public sealed class UpdateOperatingTermsCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<UpdateOperatingTermsCommand, OperatingTermsDto>
{
    public async Task<OperatingTermsDto> Handle(UpdateOperatingTermsCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var operatingTerms = await context.OperatingTerms.FindAsync([request.Id], cancellationToken);
        
        if (operatingTerms == null)
            throw new Exception("Operating terms not found");

        operatingTerms.ProductionDate = request.ProductionDate;
        operatingTerms.DeliveryDate = request.DeliveryDate;
        operatingTerms.InstallationDate = request.InstallationDate;
        operatingTerms.GuaranteeExpirationDate = request.GuaranteeExpirationDate;
        operatingTerms.ExploitationTime = request.ExploitationTime;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<OperatingTermsDto>(operatingTerms);
    }
} 