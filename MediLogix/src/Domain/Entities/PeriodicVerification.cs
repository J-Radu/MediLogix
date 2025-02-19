namespace MediLogix.Domain.Entities;

public class PeriodicVerification : EntityBase
{
    public bool IsSubject { get; set; }
    public TimeSpan VerificationPeriodicity { get; set; }
    public string CertificateNumber { get; set; }
    public DateOnly LastVerificationDate { get; set; }
    public DateOnly IssueDate { get; set; }
    public virtual Device Device { get; set; }
}