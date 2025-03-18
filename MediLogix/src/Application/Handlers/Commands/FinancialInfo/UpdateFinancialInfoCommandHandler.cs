namespace MediLogix.Application.Handlers.Commands.FinancialInfo;

public sealed class UpdateFinancialInfoCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<UpdateFinancialInfoCommand, FinancialInfoDto>
{
    public async Task<FinancialInfoDto> Handle(UpdateFinancialInfoCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var financialInfo = await context.FinancialInfos.FindAsync([request.Id], cancellationToken);
        
        if (financialInfo == null)
            throw new Exception("Financial Info not found");
        financialInfo.AcquisitionPrice = request.AcquisitionPrice;
        financialInfo.Currency = request.Currency;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<FinancialInfoDto>(financialInfo);
    }
} 