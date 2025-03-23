namespace MediLogix.Application.Handlers.Commands.CurrentLocation;

public sealed class CreateCurrentLocationCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<CreateCurrentLocationCommand, CurrentLocationDto>
{
    public async Task<CurrentLocationDto> Handle(CreateCurrentLocationCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var currentLocation = new Domain.Entities.CurrentLocation
        {
            Id = request.Id,
            IMS = request.IMS,
            Department = request.Department,
            Localization = request.Localization,
            Status = request.Status
        };

        await context.CurrentLocations.AddAsync(currentLocation, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CurrentLocationDto>(currentLocation);
    }
} 