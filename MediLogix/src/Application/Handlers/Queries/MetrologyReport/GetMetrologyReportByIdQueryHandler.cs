using MediLogix.Application.Queries.MetrologyReport;

namespace MediLogix.Application.Handlers.Queries.MetrologyReport;

public sealed class GetMetrologyReportByIdQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetMetrologyReportByIdQuery, MetrologyReportDto>
{
    public async Task<MetrologyReportDto> Handle(GetMetrologyReportByIdQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var report = await context.MetrologyReports
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (report == null)
        {
            return null;
        }

        return new MetrologyReportDto
        {
            Id = report.Id,
            DeviceId = report.DeviceId,
            ReportNumber = report.ReportNumber,
            IssueDate = report.IssueDate,
            ExpirationDate = report.ExpirationDate,
            IssuingAuthority = report.IssuingAuthority,
            Findings = report.Findings,
            Recommendations = report.Recommendations,
            IsApproved = report.IsApproved,
            DocumentName = report.DocumentName,
            DocumentType = report.DocumentType,
            DocumentData = report.DocumentData,
            DocumentSize = report.DocumentSize,
            UploadDate = report.UploadDate
        };
    }
} 