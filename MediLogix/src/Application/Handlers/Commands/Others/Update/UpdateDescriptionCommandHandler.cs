namespace MediLogix.Application.Handlers.Commands.Others.Update;

public sealed class UpdateDescriptionCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<UpdateDescriptionCommand, DescriptionDto>
{
    public async Task<DescriptionDto> Handle(UpdateDescriptionCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var description = await context.Descriptions.FindAsync([request.Id], cancellationToken);
        
        if (description == null)
            throw new Exception("Description not found");

        description.DeviceName = request.DeviceName;
        description.DeviceDescription = request.DeviceDescription;
        description.DeviceNumber = request.DeviceNumber;
        description.InventoryNumber = request.InventoryNumber;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<DescriptionDto>(description);
    }
} 