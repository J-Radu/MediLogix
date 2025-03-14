namespace MediLogix.Application.Handlers.Queries.Device;

public class GetDeviceByIdQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetDeviceByIdQuery, DeviceDto>
{
    public async Task<DeviceDto> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
    {
        var device = await context.Devices
            .Include(d => d.Model)
            .Include(d => d.Description)
            .Include(d => d.FinancialInfo)
            .Include(d => d.OperatingTerms)
            .Include(d => d.WarrantyAndMaintenance)
            .Include(d => d.PeriodicVerification)
            .Include(d => d.CurrentLocation)
            .Include(d => d.Pieces)
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

        if (device == null)
        {
            return null;
        }

        return new DeviceDto
        {
            Id = device.Id,
                
            // Model
            DmModel = device.Model?.DmModel,
            GMDN = device.Model?.GMDN,
            Manufacturer = device.Model?.Manufacturer,
            Country = device.Model?.Country,
                
            // Description
            DeviceName = device.Description?.DeviceName,
            DeviceDescription = device.Description?.DeviceDescription,
            DeviceNumber = device.Description?.DeviceNumber,
            InventoryNumber = device.Description?.InventoryNumber,
                
            // FinancialInfo
            AcquisitionPrice = device.FinancialInfo?.AcquisitionPrice ?? 0,
            Currency = device.FinancialInfo?.Currency,
                
            // OperatingTerms
            ProductionDate = device.OperatingTerms?.ProductionDate ?? default,
            DeliveryDate = device.OperatingTerms?.DeliveryDate ?? default,
            InstallationDate = device.OperatingTerms?.InstallationDate ?? default,
            GuaranteeExpirationDate = device.OperatingTerms?.GuaranteeExpirationDate ?? default,
            ExploitationTime = device.OperatingTerms?.ExploitationTime ?? default,
                
            // WarrantyAndMaintenance
            ContractNumber = device.WarrantyAndMaintenance?.ContractNumber,
            MaintenanceContract = device.WarrantyAndMaintenance?.MaintenanceContract,
            Provider = device.WarrantyAndMaintenance?.Provider,
            ServiceAgent = device.WarrantyAndMaintenance?.ServiceAgent,
            ExpirationDate = device.WarrantyAndMaintenance?.ExpirationDate ?? default,
                
            // PeriodicVerification
            IsSubject = device.PeriodicVerification?.IsSubject ?? false,
            VerificationPeriodicity = device.PeriodicVerification?.VerificationPeriodicity ?? default,
            CertificateNumber = device.PeriodicVerification?.CertificateNumber,
            LastVerificationDate = device.PeriodicVerification?.LastVerificationDate ?? default,
            IssueDate = device.PeriodicVerification?.IssueDate ?? default,
                
            // CurrentLocation
            IMS = device.CurrentLocation?.IMS,
            Department = device.CurrentLocation?.Department,
            Localization = device.CurrentLocation?.Localization,
            Status = device.CurrentLocation?.Status,
                
            // Pieces
            PieceDtos = device.Pieces?.Select(p => new PieceDto
            {
                Id = p.Id,
                DeviceId = p.DeviceId,
                Name = p.Name,
                Price = p.Price,
                AcquisitionDate = p.AcquisitionDate
            }).ToList() ?? new List<PieceDto>()
        };
    }
} 