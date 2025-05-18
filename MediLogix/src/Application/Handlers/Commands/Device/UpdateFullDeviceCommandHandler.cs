namespace MediLogix.Application.Handlers.Commands.Device;

public sealed class UpdateFullDeviceCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory, IMapper mapper)
    : IRequestHandler<UpdateFullDeviceCommand, FullDeviceDto>
{
    public async Task<FullDeviceDto> Handle(UpdateFullDeviceCommand request, CancellationToken cancellationToken)
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
        device.PeriodicVerification.VerificationPeriodicityMonths = request.VerificationPeriodicityMonths;
        device.PeriodicVerification.CertificateNumber = request.CertificateNumber;
        device.PeriodicVerification.LastVerificationDate = request.LastVerificationDate;
        device.PeriodicVerification.IssueDate = request.IssueDate;

        // Update CurrentLocation
        device.CurrentLocation.IMS = request.IMS;
        device.CurrentLocation.Department = request.Department;
        device.CurrentLocation.Localization = request.Localization;
        device.CurrentLocation.Status = request.Status;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<FullDeviceDto>(device);
    }
} 