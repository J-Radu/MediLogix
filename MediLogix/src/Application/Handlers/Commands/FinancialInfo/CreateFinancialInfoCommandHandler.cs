namespace MediLogix.Application.Handlers.Commands.FinancialInfo;

public sealed class CreateFinancialInfoCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<CreateFinancialInfoCommand, FinancialInfoDto>
{
    public async Task<FinancialInfoDto> Handle(CreateFinancialInfoCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var financialInfo = new Domain.Entities.FinancialInfo
        {
            AcquisitionPrice = request.AcquisitionPrice,
            Currency = request.Currency
        };

        await context.FinancialInfos.AddAsync(financialInfo, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<FinancialInfoDto>(financialInfo);
    }
} 