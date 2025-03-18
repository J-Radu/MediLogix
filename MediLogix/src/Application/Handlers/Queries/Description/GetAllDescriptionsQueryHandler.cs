using MediLogix.Application.Queries.Description;

namespace MediLogix.Application.Handlers.Queries.Description;

public sealed class GetAllDescriptionsQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllDescriptionsQuery, List<DescriptionDto>>
{
    public async Task<List<DescriptionDto>> Handle(GetAllDescriptionsQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
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