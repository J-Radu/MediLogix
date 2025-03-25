using MediLogix.Application.Queries.PeriodicVerification;

namespace MediLogix.Application.Handlers.Queries.PeriodicVerification;

public sealed class GetPeriodicVerificationByIdQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetPeriodicVerificationByIdQuery, PeriodicVerificationDto>
{
    public async Task<PeriodicVerificationDto> Handle(GetPeriodicVerificationByIdQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var periodicVerification = await context.PeriodicVerifications
            .AsNoTracking()
            .FirstOrDefaultAsync(pv => pv.Id == request.Id, cancellationToken);

        if (periodicVerification == null)
        {
            return null;
        }

        return new PeriodicVerificationDto
        {
            Id = periodicVerification.Id,
            IsSubject = periodicVerification.IsSubject,
            VerificationPeriodicityMonths = periodicVerification.VerificationPeriodicityMonths,
            CertificateNumber = periodicVerification.CertificateNumber,
            LastVerificationDate = periodicVerification.LastVerificationDate,
            IssueDate = periodicVerification.IssueDate
        };
    }
} 