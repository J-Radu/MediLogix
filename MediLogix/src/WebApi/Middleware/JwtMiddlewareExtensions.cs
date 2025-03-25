using Microsoft.Extensions.Caching.Memory;

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
    
    public static void BlacklistToken(this IMemoryCache cache, string token, TimeSpan duration)
    {
        var cacheKey = $"blacklisted_token_{token}";
        cache.Set(cacheKey, true, duration);
    }
} 