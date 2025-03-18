namespace MediLogix.Application.Handlers.Commands.Device;

public sealed class CreateDeviceCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory, IMapper mapper)
    : IRequestHandler<CreateDeviceCommand, DeviceDto>
{
    public async Task<DeviceDto> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var device = new Domain.Entities.Device();

        // Create and associate Model
        var model = new Domain.Entities.Model
        {
            DmModel = request.DmModel,
            GMDN = request.GMDN,
            Manufacturer = request.Manufacturer,
            Country = request.Country
        };
        device.Model = model;

        // Create and associate Description
        var description = new Domain.Entities.Description
        {
            DeviceName = request.DeviceName,
            DeviceDescription = request.DeviceDescription,
            DeviceNumber = request.DeviceNumber,
            InventoryNumber = request.InventoryNumber
        };
        device.Description = description;

        // Create and associate FinancialInfo
        var financialInfo = new Domain.Entities.FinancialInfo
        {
            AcquisitionPrice = request.AcquisitionPrice,
            Currency = request.Currency
        };
        device.FinancialInfo = financialInfo;

        // Create and associate OperatingTerms
        var operatingTerms = new Domain.Entities.OperatingTerms
        {
            ProductionDate = request.ProductionDate,
            DeliveryDate = request.DeliveryDate,
            InstallationDate = request.InstallationDate,
            GuaranteeExpirationDate = request.GuaranteeExpirationDate,
            ExploitationTime = request.ExploitationTime
        };
        device.OperatingTerms = operatingTerms;

        // Create and associate WarrantyAndMaintenance
        var warrantyAndMaintenance = new Domain.Entities.WarrantyAndMaintenance
        {
            ContractNumber = request.ContractNumber,
            MaintenanceContract = request.MaintenanceContract,
            Provider = request.Provider,
            ServiceAgent = request.ServiceAgent,
            ExpirationDate = request.ExpirationDate
        };
        device.WarrantyAndMaintenance = warrantyAndMaintenance;

        // Create and associate PeriodicVerification
        var periodicVerification = new Domain.Entities.PeriodicVerification
        {
            IsSubject = request.IsSubject,
            VerificationPeriodicity = request.VerificationPeriodicity,
            CertificateNumber = request.CertificateNumber,
            LastVerificationDate = request.LastVerificationDate,
            IssueDate = request.IssueDate
        };
        device.PeriodicVerification = periodicVerification;

        // Create and associate CurrentLocation
        var currentLocation = new Domain.Entities.CurrentLocation
        {
            IMS = request.IMS,
            Department = request.Department,
            Localization = request.Localization,
            Status = request.Status
        };
        device.CurrentLocation = currentLocation;

        // Create and associate Failure if exists
        if (!string.IsNullOrEmpty(request.FailureType) || !string.IsNullOrEmpty(request.FailureDescription))
        {
            var failure = new Domain.Entities.Failure
            {
                FailureType = request.FailureType,
                FailureDescription = request.FailureDescription
            };
            device.Failures.Add(failure);
        }

        // Create and associate MetrologyReport
        var metrologyReport = new Domain.Entities.MetrologyReport
        {
            ReportNumber = request.ReportNumber,
            IssueDate = request.ReportIssueDate,
            ExpirationDate = request.ReportExpirationDate,
            IssuingAuthority = request.IssuingAuthority,
            Findings = request.Findings,
            Recommendations = request.Recommendations,
            IsApproved = request.IsApproved,
            DocumentName = request.DocumentName,
            DocumentType = request.DocumentType,
            DocumentData = request.DocumentData,
            DocumentSize = request.DocumentSize,
            UploadDate = request.UploadDate
        };
        device.MetrologyReports.Add(metrologyReport);

        await context.Devices.AddAsync(device, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<DeviceDto>(device);
    }
} 