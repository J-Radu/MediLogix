namespace MediLogix.WebApi.Middleware;

public class JwtMiddleware(
    RequestDelegate next,
    IConfiguration configuration,
    ILogger<JwtMiddleware> logger)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var authHeader = context.Request.Headers["Authorization"].ToString();
        
        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            var tokenPart = authHeader.Substring("Bearer ".Length).Trim();
            
            if (tokenPart.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                tokenPart = tokenPart.Substring("Bearer ".Length).Trim();
                logger.LogInformation("Detected and removed duplicate 'Bearer' prefix");
            }
            
            try
            {
                var handler = new JwtSecurityTokenHandler();
                if (handler.CanReadToken(tokenPart))
                {
                    var jwtToken = handler.ReadJwtToken(tokenPart);
                    
                    var claims = jwtToken.Claims.ToList();
                    var identity = new ClaimsIdentity(claims, "JWT");
                    var principal = new ClaimsPrincipal(identity);
                    
                    context.User = principal;
                    logger.LogInformation("JWT token processed (validation bypassed)");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing JWT token: {Message}", ex.Message);
            }
        }
        
        await _next(context);
    }
}