namespace MediLogix.Application.Commands.Activity;

public sealed class UpdateActivityCommand : IRequest<ActivityDto>
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public DateOnly EventDate { get; set; }
    public string EventName { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsSuccessful { get; set; }
    public string? Notes { get; set; }
} 