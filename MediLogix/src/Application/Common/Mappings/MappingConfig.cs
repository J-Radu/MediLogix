namespace MediLogix.Application.Common.Mappings;

public static class MappingConfig
{
    public static void AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(MappingConfig).Assembly); 

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
    }
} 