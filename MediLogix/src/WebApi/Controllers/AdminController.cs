namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")] 
public class AdminController(IActivityLogRepository activityLogRepository, UserManager<ApplicationUser> userManager)
    : ControllerBase
{
    [HttpGet("logs")]
    public async Task<ActionResult<IEnumerable<ActivityLog>>> GetLogs(
        [FromQuery] DateTime? fromDate,
        [FromQuery] DateTime? toDate,
        [FromQuery] string? userId)
    {
        var logs = await activityLogRepository.GetLogsAsync(fromDate, toDate, userId);
        return Ok(logs);
    }

    [HttpGet("logs/{id}")]
    public async Task<ActionResult<ActivityLog>> GetLogById(int id)
    {
        var log = await activityLogRepository.GetLogByIdAsync(id);

        if (log == null)
            return NotFound();

        return Ok(log);
    }

    [HttpGet("users")]
    public Task<ActionResult<IEnumerable<object>>> GetUsers()
    {
        var users = userManager.Users.ToList();
        
        var usersList = users.Select(user => new
        {
            user.Id,
            user.UserName,
            user.Email,
            user.PhoneNumber,
            user.EmailConfirmed,
            user.LockoutEnabled,
            user.LockoutEnd
        });
        
        return Task.FromResult<ActionResult<IEnumerable<object>>>(Ok(usersList));
    }
} 