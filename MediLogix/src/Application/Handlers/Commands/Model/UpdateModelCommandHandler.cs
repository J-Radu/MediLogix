namespace MediLogix.Application.Handlers.Commands.Model;

public sealed class UpdateModelCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<UpdateModelCommand, ModelDto>
{
    public async Task<ModelDto> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var model = await context.Models
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (model == null)
            throw new Exception("Model not found");

        model.DmModel = request.DmModel;
        model.GMDN = request.GMDN;
        model.Manufacturer = request.Manufacturer;
        model.Country = request.Country;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<ModelDto>(model);
    }
} 