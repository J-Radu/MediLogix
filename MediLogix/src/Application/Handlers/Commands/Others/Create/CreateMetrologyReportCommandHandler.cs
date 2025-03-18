namespace MediLogix.Application.Handlers.Commands.Others.Create;

public sealed class CreateMetrologyReportCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<CreateMetrologyReportCommand, MetrologyReportDto>
{
    public async Task<MetrologyReportDto> Handle(CreateMetrologyReportCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var metrologyReport = new MetrologyReport
        {
            DeviceId = request.DeviceId,
            ReportNumber = request.ReportNumber,
            IssueDate = request.IssueDate,
            ExpirationDate = request.ExpirationDate,
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

        await context.MetrologyReports.AddAsync(metrologyReport, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<MetrologyReportDto>(metrologyReport);
    }
} 