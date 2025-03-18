namespace MediLogix.Application.Handlers.Commands.Device;

public sealed class UpdateDeviceCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory, IMapper mapper)
    : IRequestHandler<UpdateDeviceCommand, DeviceDto>
{
    public async Task<DeviceDto> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var device = await context.Devices
            .Include(d => d.Model)
            .Include(d => d.Description)
            .Include(d => d.FinancialInfo)
            .Include(d => d.OperatingTerms)
            .Include(d => d.WarrantyAndMaintenance)
            .Include(d => d.PeriodicVerification)
            .Include(d => d.CurrentLocation)
            .Include(d => d.Failures)
            .Include(d => d.MetrologyReports)
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

        if (device == null)
            throw new Exception("Device not found");

        // Update Model
        device.Model.DmModel = request.DmModel;
        device.Model.GMDN = request.GMDN;
        device.Model.Manufacturer = request.Manufacturer;
        device.Model.Country = request.Country;

        // Update Description
        device.Description.DeviceName = request.DeviceName;
        device.Description.DeviceDescription = request.DeviceDescription;
        device.Description.DeviceNumber = request.DeviceNumber;
        device.Description.InventoryNumber = request.InventoryNumber;

        // Update FinancialInfo
        device.FinancialInfo.AcquisitionPrice = request.AcquisitionPrice;
        device.FinancialInfo.Currency = request.Currency;

        // Update OperatingTerms
        device.OperatingTerms.ProductionDate = request.ProductionDate;
        device.OperatingTerms.DeliveryDate = request.DeliveryDate;
        device.OperatingTerms.InstallationDate = request.InstallationDate;
        device.OperatingTerms.GuaranteeExpirationDate = request.GuaranteeExpirationDate;
        device.OperatingTerms.ExploitationTime = request.ExploitationTime;

        // Update WarrantyAndMaintenance
        device.WarrantyAndMaintenance.ContractNumber = request.ContractNumber;
        device.WarrantyAndMaintenance.MaintenanceContract = request.MaintenanceContract;
        device.WarrantyAndMaintenance.Provider = request.Provider;
        device.WarrantyAndMaintenance.ServiceAgent = request.ServiceAgent;
        device.WarrantyAndMaintenance.ExpirationDate = request.ExpirationDate;

        // Update PeriodicVerification
        device.PeriodicVerification.IsSubject = request.IsSubject;
        device.PeriodicVerification.VerificationPeriodicity = request.VerificationPeriodicity;
        device.PeriodicVerification.CertificateNumber = request.CertificateNumber;
        device.PeriodicVerification.LastVerificationDate = request.LastVerificationDate;
        device.PeriodicVerification.IssueDate = request.IssueDate;

        // Update CurrentLocation
        device.CurrentLocation.IMS = request.IMS;
        device.CurrentLocation.Department = request.Department;
        device.CurrentLocation.Localization = request.Localization;
        device.CurrentLocation.Status = request.Status;

        // Update Failure
        var failure = device.Failures.FirstOrDefault();
        if (failure != null)
        {
            failure.FailureType = request.FailureType;
            failure.FailureDescription = request.FailureDescription;
        }
        else if (!string.IsNullOrEmpty(request.FailureType) || !string.IsNullOrEmpty(request.FailureDescription))
        {
            device.Failures.Add(new Failure
            {
                FailureType = request.FailureType,
                FailureDescription = request.FailureDescription
            });
        }

        // Update MetrologyReport
        var metrologyReport = device.MetrologyReports.FirstOrDefault();
        if (metrologyReport != null)
        {
            metrologyReport.ReportNumber = request.ReportNumber;
            metrologyReport.IssueDate = request.ReportIssueDate;
            metrologyReport.ExpirationDate = request.ReportExpirationDate;
            metrologyReport.IssuingAuthority = request.IssuingAuthority;
            metrologyReport.Findings = request.Findings;
            metrologyReport.Recommendations = request.Recommendations;
            metrologyReport.IsApproved = request.IsApproved;
            metrologyReport.DocumentName = request.DocumentName;
            metrologyReport.DocumentType = request.DocumentType;
            metrologyReport.DocumentData = request.DocumentData;
            metrologyReport.DocumentSize = request.DocumentSize;
            metrologyReport.UploadDate = request.UploadDate;
        }

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<DeviceDto>(device);
    }
} 