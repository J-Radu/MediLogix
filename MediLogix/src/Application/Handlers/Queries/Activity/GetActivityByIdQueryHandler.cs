namespace MediLogix.Application.Handlers.Queries.Activity;

public class GetActivityByIdQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetActivityByIdQuery, ActivityDto>
{
    public async Task<ActivityDto> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        var activity = await context.Activities
            .Include(a => a.Employee)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        if (activity == null)
        {
            return null;
        }

        return new ActivityDto
        {
            Id = activity.Id,
            EmployeeId = activity.EmployeeId,
            EventDate = activity.EventDate,
            EventName = activity.EventName,
            IsCompleted = activity.IsCompleted,
            IsSuccessful = activity.IsSuccessful,
            Notes = activity.Notes
        };
    }
} 