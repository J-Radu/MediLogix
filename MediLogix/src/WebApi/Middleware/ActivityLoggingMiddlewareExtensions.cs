namespace MediLogix.WebApi.Middleware;

public static class ActivityLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseActivityLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ActivityLoggingMiddleware>();
    }
}