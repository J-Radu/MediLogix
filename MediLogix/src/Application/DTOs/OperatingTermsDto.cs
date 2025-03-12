namespace MediLogix.Application.DTOs;

public class OperatingTermsDto : EntityBase
{
    public DateOnly ProductionDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public DateOnly InstallationDate { get; set; }
    public DateOnly GuaranteeExpirationDate { get; set; }
    public DateOnly ExploitationTime { get; set; }
}