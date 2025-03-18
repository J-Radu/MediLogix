namespace MediLogix.Application.Commands.Others.Update;

public abstract class UpdateFinancialInfoCommand : EntityBase, IRequest<FinancialInfoDto>
{
    public double AcquisitionPrice { get; set; }
    public string Currency { get; set; }
} 