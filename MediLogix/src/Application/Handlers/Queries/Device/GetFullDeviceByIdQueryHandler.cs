namespace MediLogix.Application.Handlers.Queries.Device;

public sealed class GetFullDeviceByIdQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetFullDeviceByIdQuery, FullDeviceDto>
{
    public async Task<FullDeviceDto> Handle(GetFullDeviceByIdQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var device = await context.Devices
            .Include(d => d.Model)
            .Include(d => d.Description)
            .Include(d => d.FinancialInfo)
            .Include(d => d.OperatingTerms)
            .Include(d => d.WarrantyAndMaintenance)
            .Include(d => d.PeriodicVerification)
            .Include(d => d.CurrentLocation)
            .Include(d => d.Pieces)
            .Include(d => d.Failures)
            .Include(d => d.MetrologyReports)
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

        if (device == null)
        {
            return null;
        }

        return new FullDeviceDto
        {
            Id = device.Id,
                
            // Model
            ModelId = device.ModelId,
            DmModel = device.Model?.DmModel,
            GMDN = device.Model?.GMDN,
            Manufacturer = device.Model?.Manufacturer,
            Country = device.Model?.Country,
                
            // Description
            DescriptionId = device.DescriptionId,
            DeviceName = device.Description?.DeviceName,
            DeviceDescription = device.Description?.DeviceDescription,
            DeviceNumber = device.Description?.DeviceNumber,
            InventoryNumber = device.Description?.InventoryNumber,
                
            // FinancialInfo
            FinancialInfoId = device.FinancialInfoId,
            AcquisitionPrice = device.FinancialInfo?.AcquisitionPrice ?? 0,
            Currency = device.FinancialInfo?.Currency,
                
            // OperatingTerms
            OperatingTermsId = device.OperatingTermsId,
            ProductionDate = device.OperatingTerms?.ProductionDate ?? default,
            DeliveryDate = device.OperatingTerms?.DeliveryDate ?? default,
            InstallationDate = device.OperatingTerms?.InstallationDate ?? default,
            GuaranteeExpirationDate = device.OperatingTerms?.GuaranteeExpirationDate ?? default,
            ExploitationTime = device.OperatingTerms?.ExploitationTime ?? default,
                
            // WarrantyAndMaintenance
            WarrantyAndMaintenanceId = device.WarrantyAndMaintenanceId,
            ContractNumber = device.WarrantyAndMaintenance?.ContractNumber,
            MaintenanceContract = device.WarrantyAndMaintenance?.MaintenanceContract,
            Provider = device.WarrantyAndMaintenance?.Provider,
            ServiceAgent = device.WarrantyAndMaintenance?.ServiceAgent,
            ExpirationDate = device.WarrantyAndMaintenance?.ExpirationDate ?? default,
                
            // PeriodicVerification
            PeriodicVerificationId = device.PeriodicVerificationId,
            IsSubject = device.PeriodicVerification?.IsSubject ?? false,
            VerificationPeriodicity = device.PeriodicVerification?.VerificationPeriodicity ?? default,
            CertificateNumber = device.PeriodicVerification?.CertificateNumber,
            LastVerificationDate = device.PeriodicVerification?.LastVerificationDate ?? default,
            IssueDate = device.PeriodicVerification?.IssueDate ?? default,
                
            // CurrentLocation
            CurrentLocationId = device.CurrentLocationId,
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
            }).ToList() ?? new List<PieceDto>(),

            // Failure
            FailureId = device.Failures?.FirstOrDefault()?.Id,
            FailureType = device.Failures?.FirstOrDefault()?.FailureType,
            FailureDescription = device.Failures?.FirstOrDefault()?.FailureDescription,
            
            // MetrologyReport
            MetrologyReportId = device.MetrologyReports?.FirstOrDefault()?.Id,
            DeviceId = device.Id,
            ReportNumber = device.MetrologyReports?.FirstOrDefault()?.ReportNumber,
            ReportIssueDate = device.MetrologyReports?.FirstOrDefault()?.IssueDate ?? default,
            ReportExpirationDate = device.MetrologyReports?.FirstOrDefault()?.ExpirationDate ?? default,
            IssuingAuthority = device.MetrologyReports?.FirstOrDefault()?.IssuingAuthority,
            Findings = device.MetrologyReports?.FirstOrDefault()?.Findings,
            Recommendations = device.MetrologyReports?.FirstOrDefault()?.Recommendations,
            IsApproved = device.MetrologyReports?.FirstOrDefault()?.IsApproved ?? false,
            DocumentName = device.MetrologyReports?.FirstOrDefault()?.DocumentName,
            DocumentType = device.MetrologyReports?.FirstOrDefault()?.DocumentType,
            DocumentData = device.MetrologyReports?.FirstOrDefault()?.DocumentData,
            DocumentSize = device.MetrologyReports?.FirstOrDefault()?.DocumentSize ?? 0,
            UploadDate = device.MetrologyReports?.FirstOrDefault()?.UploadDate ?? default
        };
    }
} 