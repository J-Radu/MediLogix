namespace MediLogix.Domain.Entities;

public class Device : EntityBase
{
    public Guid EmployeeId { get; set; }
    public Guid DescriptionId { get; set; }
    public Guid ModelId { get; set; }
    public Guid WarrantyAndMaintenanceId { get; set; }
    public Guid PeriodicVerificationId { get; set; }
    public Guid OperatingTermsId { get; set; }
    public Guid FinancialInfoId { get; set; }
    public Guid CurrentLocationId { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual Description Description { get; set; }
    public virtual Model Model { get; set; }
    public virtual WarrantyAndMaintenance WarrantyAndMaintenance { get; set; }
    public virtual PeriodicVerification PeriodicVerification { get; set; }
    public virtual OperatingTerms OperatingTerms { get; set; }
    public virtual FinancialInfo FinancialInfo { get; set; }
    public virtual CurrentLocation CurrentLocation { get; set; }
    public virtual ICollection<Piece> Pieces { get; set; }
}