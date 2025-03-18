namespace MediLogix.Application.Handlers.Queries.Activity;

public sealed class GetAllActivitiesQueryHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<GetAllActivitiesQuery, List<ActivityDto>>
{
    public async Task<List<ActivityDto>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var activities = await context.Activities
            .Include(a => a.Employee)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return activities.Select(a => new ActivityDto
        {
            Id = a.Id,
            EmployeeId = a.EmployeeId,
            EventName = a.EventName,
            EventDate = a.EventDate,
            Notes = a.Notes,
            IsCompleted = a.IsCompleted,
            IsSuccessful = a.IsSuccessful,
        }).ToList();
    }
} 