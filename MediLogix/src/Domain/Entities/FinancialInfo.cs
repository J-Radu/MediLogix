namespace MediLogix.Domain.Entities;

public sealed class FinancialInfo : EntityBase
{
    public double AcquisitionPrice { get; set; }
    public string Currency { get; set; }
    public Device? Device { get; set; }
}