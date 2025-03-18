namespace MediLogix.Application.Commands.Others.Create;

public sealed class CreateFinancialInfoCommand : IRequest<FinancialInfoDto>
{
    public double AcquisitionPrice { get; set; }
    public string Currency { get; set; }
} 