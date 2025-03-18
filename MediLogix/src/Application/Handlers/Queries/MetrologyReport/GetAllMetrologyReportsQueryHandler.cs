using MediLogix.Application.Queries.MetrologyReport;

namespace MediLogix.Application.Handlers.Queries.MetrologyReport;

public sealed class GetAllMetrologyReportsQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllMetrologyReportsQuery, List<MetrologyReportDto>>
{
    public async Task<List<MetrologyReportDto>> Handle(GetAllMetrologyReportsQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var reports = await context.MetrologyReports
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return reports.Select(r => new MetrologyReportDto
        {
            Id = r.Id,
            DeviceId = r.DeviceId,
            ReportNumber = r.ReportNumber,
            IssueDate = r.IssueDate,
            ExpirationDate = r.ExpirationDate,
            IssuingAuthority = r.IssuingAuthority,
            Findings = r.Findings,
            Recommendations = r.Recommendations,
            IsApproved = r.IsApproved,
            DocumentName = r.DocumentName,
            DocumentType = r.DocumentType,
            DocumentData = r.DocumentData,
            DocumentSize = r.DocumentSize,
            UploadDate = r.UploadDate
        }).ToList();
    }
} 