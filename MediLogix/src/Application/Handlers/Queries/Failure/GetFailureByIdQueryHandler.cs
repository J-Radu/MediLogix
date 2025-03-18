using MediLogix.Application.Queries.Failure;

namespace MediLogix.Application.Handlers.Queries.Failure;

public sealed class GetFailureByIdQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory) : IRequestHandler<GetFailureByIdQuery, FailureDto>
{
    public async Task<FailureDto> Handle(GetFailureByIdQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var failure = await context.Failures
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

        if (failure == null)
        {
            return null;
        }
        
        return new FailureDto
        {
            Id = failure.Id,
            DeviceId = failure.DeviceId,
            FailureDescription = failure.FailureDescription,
            FailureType = failure.FailureType,
        };
    }
}