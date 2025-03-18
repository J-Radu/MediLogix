namespace MediLogix.Application.Handlers.Commands.Others.Update;

public sealed class UpdateMetrologyReportCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<UpdateMetrologyReportCommand, MetrologyReportDto>
{
    public async Task<MetrologyReportDto> Handle(UpdateMetrologyReportCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var metrologyReport = await context.MetrologyReports.FindAsync([request.Id], cancellationToken);
        
        if (metrologyReport == null)
            throw new Exception("The metrology report does not exist.");

        metrologyReport.DeviceId = request.DeviceId;
        metrologyReport.ReportNumber = request.ReportNumber;
        metrologyReport.IssueDate = request.IssueDate;
        metrologyReport.ExpirationDate = request.ExpirationDate;
        metrologyReport.IssuingAuthority = request.IssuingAuthority;
        metrologyReport.Findings = request.Findings;
        metrologyReport.Recommendations = request.Recommendations;
        metrologyReport.IsApproved = request.IsApproved;
        metrologyReport.DocumentName = request.DocumentName;
        metrologyReport.DocumentType = request.DocumentType;
        metrologyReport.DocumentData = request.DocumentData;
        metrologyReport.DocumentSize = request.DocumentSize;
        metrologyReport.UploadDate = request.UploadDate;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<MetrologyReportDto>(metrologyReport);
    }
} 