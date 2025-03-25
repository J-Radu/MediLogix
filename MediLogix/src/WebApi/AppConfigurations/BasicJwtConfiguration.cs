using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MediLogix.WebApi.AppConfigurations;

public static class BasicJwtConfiguration
{
    public static IServiceCollection AddBasicJwtAuth(this IServiceCollection services, IConfiguration configuration)
    {
        // Elimină orice configurație de autentificare existentă
        var descriptor = services.SingleOrDefault(d => 
            d.ServiceType == typeof(Microsoft.AspNetCore.Authentication.AuthenticationOptions));
        if (descriptor != null)
        {
            services.Remove(descriptor);
        }

        // Configurație simplă
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
                    configuration["JWT:Secret"] ?? throw new InvalidOperationException("JWT:Secret nu este configurat"))),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };
            
            // Logging pentru depanare
            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"⚠️ Autentificarea a eșuat: {context.Exception}");
                    Console.ResetColor();
                    return Task.CompletedTask;
                },
                OnMessageReceived = context =>
                {
                    Console.WriteLine($"📨 Headerul Authorization primit: {context.Request.Headers["Authorization"]}");
                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✅ Token validat cu succes!");
                    Console.ResetColor();
                    return Task.CompletedTask;
                }
            };
        });

        return services;
    }
} 