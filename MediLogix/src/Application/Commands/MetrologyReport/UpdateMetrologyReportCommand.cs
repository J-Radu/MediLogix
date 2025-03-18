namespace MediLogix.Application.Commands.MetrologyReport;

public sealed class UpdateMetrologyReportCommand : EntityBase, IRequest<MetrologyReportDto>
{
    public Guid DeviceId { get; set; }
    public string ReportNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpirationDate { get; set; }
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