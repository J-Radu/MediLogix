namespace MediLogix.WebApi.AppConfigurations;

public static class DbConfiguration
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<MediLogixDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MediLogixDB"));
        });

        return services;
    }
} 