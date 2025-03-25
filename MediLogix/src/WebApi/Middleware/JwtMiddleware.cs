namespace MediLogix.WebApi.Middleware;

public class JwtMiddleware(
    RequestDelegate next,
    IConfiguration configuration,
    ILogger<JwtMiddleware> logger)
{
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
            
            if (!string.IsNullOrEmpty(tokenPart))
            {
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                    
                    var validationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ClockSkew = TimeSpan.Zero
                    };
                    
                    var principal = handler.ValidateToken(tokenPart, validationParameters, out _);
                    context.User = principal;
                    
                    logger.LogInformation("JWT token validated successfully");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "JWT validation error: {Message}", ex.Message);
                }
            }
        }
        
        await next(context);
    }
}