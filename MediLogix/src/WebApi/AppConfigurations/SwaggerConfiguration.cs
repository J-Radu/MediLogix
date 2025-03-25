using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MediLogix.WebApi.AppConfigurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            // Basic API information
            c.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "MediLogix API", 
                Version = "v1",
                Description = "Medical equipment management and maintenance API"
            });
            
            // Improved JWT authentication configuration
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter JWT token only (without Bearer prefix)",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            
            c.AddSecurityDefinition("Bearer", securityScheme);
            
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securityScheme, new List<string>() }
            });
        });
        
        return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "MediLogix API V1");
            
            // UI improvements
            options.DocExpansion(DocExpansion.None);
            options.DefaultModelsExpandDepth(-1); 
            options.EnableDeepLinking();
            options.DisplayRequestDuration();
            options.EnablePersistAuthorization();
        });

        return app;
    }
}