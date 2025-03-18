namespace MediLogix.Application.Handlers.Commands.Others.Create;

public sealed class CreatePeriodicVerificationCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<CreatePeriodicVerificationCommand, PeriodicVerificationDto>
{
    public async Task<PeriodicVerificationDto> Handle(CreatePeriodicVerificationCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var periodicVerification = new PeriodicVerification
        {
            IsSubject = request.IsSubject,
            VerificationPeriodicity = request.VerificationPeriodicity,
            CertificateNumber = request.CertificateNumber,
            LastVerificationDate = request.LastVerificationDate,
            IssueDate = request.IssueDate
        };

        await context.PeriodicVerifications.AddAsync(periodicVerification, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<PeriodicVerificationDto>(periodicVerification);
    }
} 