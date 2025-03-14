namespace MediLogix.Application.Handlers.Queries.Others.GetAll;

public class GetAllDescriptionsQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetAllDescriptionsQuery, List<DescriptionDto>>
{
    public async Task<List<DescriptionDto>> Handle(GetAllDescriptionsQuery request, CancellationToken cancellationToken)
    {
        var descriptions = await context.Descriptions
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return descriptions.Select(d => new DescriptionDto
        {
            Id = d.Id,
            DeviceName = d.DeviceName,
            DeviceDescription = d.DeviceDescription,
            DeviceNumber = d.DeviceNumber,
            InventoryNumber = d.InventoryNumber
        }).ToList();
    }
} 