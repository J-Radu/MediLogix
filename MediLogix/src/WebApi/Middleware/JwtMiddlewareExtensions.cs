namespace MediLogix.WebApi.Middleware;

public static class JwtMiddlewareExtensions
{
    public static IApplicationBuilder UseJwtValidation(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<JwtMiddleware>();
    }
    
    public static IServiceCollection AddJwtBlacklist(this IServiceCollection services)
    {
        services.AddMemoryCache();
        
        return services;
    }
} 