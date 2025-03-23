namespace MediLogix.Application.Handlers.Commands.Model;

public sealed class CreateModelCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<CreateModelCommand, ModelDto>
{
    public async Task<ModelDto> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var model = new Domain.Entities.Model
        {
            Id = request.Id,
            DmModel = request.DmModel,
            GMDN = request.GMDN,
            Manufacturer = request.Manufacturer,
            Country = request.Country
        };

        await context.Models.AddAsync(model, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<ModelDto>(model);
    }
} 