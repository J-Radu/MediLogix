namespace MediLogix.Application.Handlers.Commands.Activity;

public sealed class UpdateActivityCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory, IMapper mapper)
    : IRequestHandler<UpdateActivityCommand, ActivityDto>
{
    public async Task<ActivityDto> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var activity = await context.Activities.FindAsync([request.Id], cancellationToken);
        
        if (activity == null)
            throw new Exception("Activity not found");

        activity.EmployeeId = request.EmployeeId;
        activity.EventDate = request.EventDate;
        activity.EventName = request.EventName;
        activity.IsCompleted = request.IsCompleted;
        activity.IsSuccessful = request.IsSuccessful;
        activity.Notes = request.Notes;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<ActivityDto>(activity);
    }
} 