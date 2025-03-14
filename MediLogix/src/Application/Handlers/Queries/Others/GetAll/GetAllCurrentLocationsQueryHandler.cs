namespace MediLogix.Application.Handlers.Queries.Others.GetAll;

public class GetAllCurrentLocationsQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetAllCurrentLocationsQuery, List<CurrentLocationDto>>
{
    public async Task<List<CurrentLocationDto>> Handle(GetAllCurrentLocationsQuery request, CancellationToken cancellationToken)
    {
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