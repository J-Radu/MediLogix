namespace MediLogix.Application.Handlers.Commands.PeriodicVerification;

public sealed class UpdatePeriodicVerificationCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<UpdatePeriodicVerificationCommand, PeriodicVerificationDto>
{
    public async Task<PeriodicVerificationDto> Handle(UpdatePeriodicVerificationCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var periodicVerification = await context.PeriodicVerifications.FindAsync([request.Id], cancellationToken);
        
        if (periodicVerification == null)
            throw new Exception("Periodic verification not found");

        periodicVerification.IsSubject = request.IsSubject;
        periodicVerification.VerificationPeriodicity = request.VerificationPeriodicity;
        periodicVerification.CertificateNumber = request.CertificateNumber;
        periodicVerification.LastVerificationDate = request.LastVerificationDate;
        periodicVerification.IssueDate = request.IssueDate;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<PeriodicVerificationDto>(periodicVerification);
    }
} 