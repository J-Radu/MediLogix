namespace MediLogix.Application.Handlers.Commands.Description;

public sealed class CreateDescriptionCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<CreateDescriptionCommand, DescriptionDto>
{
    public async Task<DescriptionDto> Handle(CreateDescriptionCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var description = new Domain.Entities.Description
        {
            DeviceName = request.DeviceName,
            DeviceDescription = request.DeviceDescription,
            DeviceNumber = request.DeviceNumber,
            InventoryNumber = request.InventoryNumber
        };

        await context.Descriptions.AddAsync(description, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<DescriptionDto>(description);
    }
} 