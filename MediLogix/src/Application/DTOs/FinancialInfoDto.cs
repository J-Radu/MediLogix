namespace MediLogix.Application.DTOs;

public class FinancialInfoDto : EntityBase
{
    public double AcquisitionPrice { get; set; }
    public string Currency { get; set; }
}