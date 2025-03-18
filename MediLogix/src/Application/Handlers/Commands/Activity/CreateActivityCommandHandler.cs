namespace MediLogix.Application.Handlers.Commands.Activity;

public sealed class CreateActivityCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory, IMapper mapper)
    : IRequestHandler<CreateActivityCommand, ActivityDto>
{
    public async Task<ActivityDto> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var activity = new Domain.Entities.Activity
        {
            EmployeeId = request.EmployeeId,
            EventDate = request.EventDate,
            EventName = request.EventName,
            IsCompleted = request.IsCompleted,
            IsSuccessful = request.IsSuccessful,
            Notes = request.Notes
        };

        await context.Activities.AddAsync(activity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<ActivityDto>(activity);
    }
} 