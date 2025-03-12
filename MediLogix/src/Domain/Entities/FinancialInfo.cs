namespace MediLogix.Domain.Entities;

public class FinancialInfo : EntityBase
{
    public double AcquisitionPrice { get; set; }
    public string Currency { get; set; }
    public virtual Device? Device { get; set; }
}