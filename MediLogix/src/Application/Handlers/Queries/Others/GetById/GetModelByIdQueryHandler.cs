namespace MediLogix.Application.Handlers.Queries.Others.GetById;

public class GetModelByIdQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetModelByIdQuery, ModelDto>
{
    public async Task<ModelDto> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
    {
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