using MediLogix.Application.Queries.Failure;

namespace MediLogix.Application.Handlers.Queries.Failure;

public sealed class GetAllFailuresQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory) : IRequestHandler<GetAllFailuresQuery, List<FailureDto>>
{
    public async Task<List<FailureDto>> Handle(GetAllFailuresQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var failures = await context.Failures
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        return failures.Select(f => new FailureDto
        {
            Id = f.Id,
            DeviceId = f.DeviceId,
            FailureDescription = f.FailureDescription,
            FailureType = f.FailureType,
        }).ToList();
    }
}