namespace MediLogix.Domain.Entities;

public sealed class PeriodicVerification : EntityBase
{
    public bool IsSubject { get; set; }
    public TimeSpan VerificationPeriodicity { get; set; }
    public string CertificateNumber { get; set; }
    public DateOnly LastVerificationDate { get; set; }
    public DateOnly IssueDate { get; set; }
    public Device? Device { get; set; }
}