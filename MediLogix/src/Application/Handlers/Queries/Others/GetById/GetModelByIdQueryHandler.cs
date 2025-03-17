namespace MediLogix.Application.Handlers.Queries.Others.GetById;

public class GetModelByIdQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetModelByIdQuery, ModelDto>
{
    public async Task<ModelDto> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var model = await context.Models
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (model == null)
        {
            return null;
        }

        return new ModelDto
        {
            Id = model.Id,
            DmModel = model.DmModel,
            GMDN = model.GMDN,
            Manufacturer = model.Manufacturer,
            Country = model.Country
        };
    }
} 