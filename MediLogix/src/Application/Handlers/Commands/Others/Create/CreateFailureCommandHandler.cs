namespace MediLogix.Application.Handlers.Commands.Others.Create;

public sealed class CreateFailureCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<CreateFailureCommand, FailureDto>
{
    public async Task<FailureDto> Handle(CreateFailureCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var failure = new Failure
        {
            DeviceId = request.DeviceId,
            FailureType = request.FailureType,
            FailureDescription = request.FailureDescription
        };

        await context.Failures.AddAsync(failure, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<FailureDto>(failure);
    }
} 