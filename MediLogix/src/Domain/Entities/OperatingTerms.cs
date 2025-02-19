using System.Runtime.InteropServices.JavaScript;

namespace MediLogix.Domain.Entities;

public class OperatingTerms : EntityBase
{
    public DateOnly ProductionDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public DateOnly InstallationDate { get; set; }
    public DateOnly GuaranteeExpirationDate { get; set; }
    public DateOnly ExploitationTime { get; set; }
    public virtual Device Device { get; set; }
}