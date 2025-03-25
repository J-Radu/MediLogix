namespace MediLogix.Domain.Entities;

public sealed class Device : EntityBase
{
    public Guid EmployeeId { get; set; }
    public Guid DescriptionId { get; set; }
    public Guid ModelId { get; set; }
    public Guid WarrantyAndMaintenanceId { get; set; }
    public Guid PeriodicVerificationId { get; set; }
    public Guid OperatingTermsId { get; set; }
    public Guid FinancialInfoId { get; set; }
    public Guid CurrentLocationId { get; set; }
    public Guid FailureId { get; set; }
    public Employee? Employee { get; set; }
    public Description? Description { get; set; }
    public Model? Model { get; set; }
    public WarrantyAndMaintenance? WarrantyAndMaintenance { get; set; }
    public PeriodicVerification? PeriodicVerification { get; set; }
    public OperatingTerms? OperatingTerms { get; set; }
    public FinancialInfo? FinancialInfo { get; set; }
    public CurrentLocation? CurrentLocation { get; set; }
    public ICollection<Failure>? Failures { get; set; }
    public ICollection<Piece>? Pieces { get; set; }
    public ICollection<MetrologyReport> MetrologyReports { get; set; }
}