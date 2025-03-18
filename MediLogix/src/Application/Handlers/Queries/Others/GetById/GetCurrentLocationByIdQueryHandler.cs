namespace MediLogix.Application.Handlers.Queries.Others.GetById;

public class GetCurrentLocationByIdQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetCurrentLocationByIdQuery, CurrentLocationDto>
{
    public async Task<CurrentLocationDto> Handle(GetCurrentLocationByIdQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var currentLocation = await context.CurrentLocations
            .AsNoTracking()
            .FirstOrDefaultAsync(cl => cl.Id == request.Id, cancellationToken);

        if (currentLocation == null)
        {
            return null;
        }

        return new CurrentLocationDto
        {
            Id = currentLocation.Id,
            IMS = currentLocation.IMS,
            Department = currentLocation.Department,
            Localization = currentLocation.Localization,
            Status = currentLocation.Status
        };
    }
} 