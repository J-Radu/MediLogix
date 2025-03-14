namespace MediLogix.Application.Handlers.Queries.Others.GetById;

public class GetPeriodicVerificationByIdQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetPeriodicVerificationByIdQuery, PeriodicVerificationDto>
{
    public async Task<PeriodicVerificationDto> Handle(GetPeriodicVerificationByIdQuery request, CancellationToken cancellationToken)
    {
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
            VerificationPeriodicity = periodicVerification.VerificationPeriodicity,
            CertificateNumber = periodicVerification.CertificateNumber,
            LastVerificationDate = periodicVerification.LastVerificationDate,
            IssueDate = periodicVerification.IssueDate
        };
    }
} 