namespace MediLogix.Application.Commands.PeriodicVerification;

public sealed class CreatePeriodicVerificationCommand : EntityBase, IRequest<PeriodicVerificationDto>
{
    public bool IsSubject { get; set; }
    public short VerificationPeriodicityMonths { get; set; }
    public string CertificateNumber { get; set; }
    public DateOnly LastVerificationDate { get; set; }
    public DateOnly IssueDate { get; set; }
} 