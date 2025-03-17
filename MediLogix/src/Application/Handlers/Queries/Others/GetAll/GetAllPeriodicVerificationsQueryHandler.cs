namespace MediLogix.Application.Handlers.Queries.Others.GetAll;

public class GetAllPeriodicVerificationsQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllPeriodicVerificationsQuery, List<PeriodicVerificationDto>>
{
    public async Task<List<PeriodicVerificationDto>> Handle(GetAllPeriodicVerificationsQuery request, CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var periodicVerifications = await context.PeriodicVerifications
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return periodicVerifications.Select(pv => new PeriodicVerificationDto
        {
            Id = pv.Id,
            IsSubject = pv.IsSubject,
            VerificationPeriodicity = pv.VerificationPeriodicity,
            CertificateNumber = pv.CertificateNumber,
            LastVerificationDate = pv.LastVerificationDate,
            IssueDate = pv.IssueDate
        }).ToList();
    }
}