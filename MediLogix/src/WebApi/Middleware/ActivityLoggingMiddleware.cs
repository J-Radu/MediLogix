namespace MediLogix.WebApi.Middleware;

public class ActivityLoggingMiddleware(RequestDelegate next, ILogger<ActivityLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context, IActivityLogRepository activityLogRepository)
    {
        if (context.Request.Path.StartsWithSegments("/api") &&
            !context.Request.Path.StartsWithSegments("/api/health"))
        {
            var userId = context.User?.Identity?.IsAuthenticated == true
                ? context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "anonymous"
                : "anonymous";

            var originalBodyStream = context.Response.Body;
            var requestPath = context.Request.Path.ToString();
            var requestMethod = context.Request.Method;

            try
            {
                using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                await next(context);

                var activityLog = new ActivityLog
                {
                    UserId = userId,
                    Action = $"{requestMethod} {requestPath}",
                    Route = requestPath,
                    IpAddress = context.Connection.RemoteIpAddress?.ToString() ?? "unknown"
                };

                await activityLogRepository.AddLogAsync(activityLog);

                logger.LogInformation(
                    "User {UserId} performed {Action} from IP {IpAddress} at {Timestamp}",
                    userId, activityLog.Action, activityLog.IpAddress, activityLog.Timestamp);

                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Eroare în middleware-ul de logging");
                throw;
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }
        else
        {
            await next(context);
        }
    }
}