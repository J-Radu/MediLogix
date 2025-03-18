namespace MediLogix.Application.Handlers.Commands.Others.Update;

public sealed class UpdateFailureCommandHandler(
    IDbContextFactory<MediLogixDbContext> contextFactory,
    IMapper mapper)
    : IRequestHandler<UpdateFailureCommand, FailureDto>
{
    public async Task<FailureDto> Handle(UpdateFailureCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        
        var failure = await context.Failures.FindAsync([request.Id], cancellationToken);
        
        if (failure == null)
            throw new Exception("Failure not found");

        failure.DeviceId = request.DeviceId;
        failure.FailureType = request.FailureType;
        failure.FailureDescription = request.FailureDescription;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<FailureDto>(failure);
    }
} 