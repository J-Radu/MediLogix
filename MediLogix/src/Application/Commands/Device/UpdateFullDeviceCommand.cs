namespace MediLogix.Application.Commands.Device;

public sealed class UpdateFullDeviceCommand : EntityBase, IRequest<FullDeviceDto>
{
    //Model
    public Guid ModelId { get; set; }
    public string DmModel { get; set; }
    public string GMDN { get; set; }
    public string Manufacturer { get; set; }
    public string Country { get; set; }

    //Description
    public Guid DescriptionId { get; set; }
    public string DeviceName { get; set; }
    public string DeviceDescription { get; set; }
    public string DeviceNumber { get; set; }
    public string InventoryNumber { get; set; }
    
    //FinancialInfo
    public Guid FinancialInfoId { get; set; }
    public double AcquisitionPrice { get; set; }
    public string Currency { get; set; }
    
    //OperatingTerms
    public Guid OperatingTermsId { get; set; }
    public DateOnly ProductionDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public DateOnly InstallationDate { get; set; }
    public DateOnly GuaranteeExpirationDate { get; set; }
    public DateOnly ExploitationTime { get; set; }
    
    //WarrantyAndMaintenance
    public Guid WarrantyAndMaintenanceId { get; set; }
    public string ContractNumber { get; set; }
    public string MaintenanceContract { get; set; }
    public string Provider { get; set; }
    public string ServiceAgent { get; set; }
    public DateOnly ExpirationDate { get; set; }
    
    //PeriodicVerification
    public Guid PeriodicVerificationId { get; set; }
    public bool IsSubject { get; set; }
    public TimeSpan VerificationPeriodicity { get; set; }
    public string CertificateNumber { get; set; }
    public DateOnly LastVerificationDate { get; set; }
    public DateOnly IssueDate { get; set; }
    
    //CurrentLocation
    public Guid CurrentLocationId { get; set; }
    public string IMS { get; set; }
    public string Department { get; set; }
    public string Localization { get; set; }
    public string Status { get; set; }
    
    //Failure
    public Guid FailureId { get; set; }
    //deviceid
    public string? FailureType { get; set; }
    public string? FailureDescription { get; set; }
    
    //MetrologyReport
    public Guid MetrologyReportId { get; set; }
    public Guid DeviceId { get; set; }
    public string ReportNumber { get; set; }
    public DateTime ReportIssueDate { get; set; }
    public DateTime ReportExpirationDate { get; set; }
    public string IssuingAuthority { get; set; }
    public string Findings { get; set; }
    public string Recommendations { get; set; }
    public bool IsApproved { get; set; }
    public string DocumentName { get; set; }
    public string DocumentType { get; set; }  
    public byte[] DocumentData { get; set; }
    public long DocumentSize { get; set; }    
    public DateTime UploadDate { get; set; }
}