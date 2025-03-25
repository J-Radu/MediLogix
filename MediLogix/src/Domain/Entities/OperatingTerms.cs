using System.Runtime.InteropServices.JavaScript;

namespace MediLogix.Domain.Entities;

public sealed class OperatingTerms : EntityBase
{
    public DateOnly ProductionDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public DateOnly InstallationDate { get; set; }
    public DateOnly GuaranteeExpirationDate { get; set; }
    public DateOnly ExploitationTime { get; set; }
    public Device? Device { get; set; }
}