namespace MediLogix.Application.Handlers.Queries.Others.GetById;

public class GetDescriptionByIdQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetDescriptionByIdQuery, DescriptionDto>
{
    public async Task<DescriptionDto> Handle(GetDescriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var description = await context.Descriptions
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

        if (description == null)
        {
            return null;
        }

        return new DescriptionDto
        {
            Id = description.Id,
            DeviceName = description.DeviceName,
            DeviceDescription = description.DeviceDescription,
            DeviceNumber = description.DeviceNumber,
            InventoryNumber = description.InventoryNumber
        };
    }
} 