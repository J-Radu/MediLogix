namespace MediLogix.Application.DTOs;

public class PeriodicVerificationDto : EntityBase
{
    public bool IsSubject { get; set; }
    public TimeSpan VerificationPeriodicity { get; set; }
    public string CertificateNumber { get; set; }
    public DateOnly LastVerificationDate { get; set; }
    public DateOnly IssueDate { get; set; }
}