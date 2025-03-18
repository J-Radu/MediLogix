using MediLogix.Application.Queries.CurrentLocation;

namespace MediLogix.Application.Handlers.Queries.CurrentLocation;

public sealed class GetAllCurrentLocationsQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllCurrentLocationsQuery, List<CurrentLocationDto>>
{
    public async Task<List<CurrentLocationDto>> Handle(GetAllCurrentLocationsQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var currentLocations = await context.CurrentLocations
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return currentLocations.Select(cl => new CurrentLocationDto
        {
            Id = cl.Id,
            IMS = cl.IMS,
            Department = cl.Department,
            Localization = cl.Localization,
            Status = cl.Status
        }).ToList();
    }
} 