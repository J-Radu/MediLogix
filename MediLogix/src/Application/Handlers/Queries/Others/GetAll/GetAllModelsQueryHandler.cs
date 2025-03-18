namespace MediLogix.Application.Handlers.Queries.Others.GetAll;

public class GetAllModelsQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllModelsQuery, List<ModelDto>>
{
    public async Task<List<ModelDto>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var models = await context.Models
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return models.Select(m => new ModelDto
        {
            Id = m.Id,
            DmModel = m.DmModel,
            GMDN = m.GMDN,
            Manufacturer = m.Manufacturer,
            Country = m.Country
        }).ToList();
    }
} 