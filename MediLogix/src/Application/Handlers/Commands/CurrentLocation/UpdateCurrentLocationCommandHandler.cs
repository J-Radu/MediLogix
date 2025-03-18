namespace MediLogix.Application.Handlers.Commands.CurrentLocation;

public sealed class UpdateCurrentLocationCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<UpdateCurrentLocationCommand, CurrentLocationDto>
{
    public async Task<CurrentLocationDto> Handle(UpdateCurrentLocationCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var currentLocation = await context.CurrentLocations.FindAsync([request.Id], cancellationToken);
        
        if (currentLocation == null)
            throw new Exception("Current Location not found");

        currentLocation.IMS = request.IMS;
        currentLocation.Department = request.Department;
        currentLocation.Localization = request.Localization;
        currentLocation.Status = request.Status;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CurrentLocationDto>(currentLocation);
    }
} 