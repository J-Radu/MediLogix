namespace MediLogix.WebApi.AppConfigurations;

public static class BasicJwtConfiguration
{
    public static IServiceCollection AddBasicJwtAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var descriptor = services.SingleOrDefault(d => 
            d.ServiceType == typeof(Microsoft.AspNetCore.Authentication.AuthenticationOptions));
        if (descriptor != null)
        {
            services.Remove(descriptor);
        }

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    configuration["JWT:Secret"] ?? throw new InvalidOperationException("JWT:Secret isn't set"))),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };
            
            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"⚠️ Authentication failed: {context.Exception}");
                    Console.ResetColor();
                    return Task.CompletedTask;
                },
                OnMessageReceived = context =>
                {
                    Console.WriteLine($"📨 Authorization header received: {context.Request.Headers["Authorization"]}");
                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✅ Token validated successfully!");
                    Console.ResetColor();
                    return Task.CompletedTask;
                }
            };
        });

        return services;
    }
} 