namespace MediLogix.Application.Commands.FinancialInfo;

public sealed class UpdateFinancialInfoCommand : EntityBase, IRequest<FinancialInfoDto>
{
    public double AcquisitionPrice { get; set; }
    public string Currency { get; set; }
} 