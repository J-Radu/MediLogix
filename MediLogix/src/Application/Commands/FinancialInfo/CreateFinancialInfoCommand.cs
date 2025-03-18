namespace MediLogix.Application.Commands.FinancialInfo;

public sealed class CreateFinancialInfoCommand : IRequest<FinancialInfoDto>
{
    public double AcquisitionPrice { get; set; }
    public string Currency { get; set; }
} 