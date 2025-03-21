var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDatabaseServices(builder.Configuration);

builder.Services.AddSwaggerDocumentation();

builder.Services.AddApplicationServices();

// Add JWT Configuration
builder.Services.AddJwtAuthentication(builder.Configuration);

// Add Identity
builder.Services.AddIdentityServices();

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddMappings();
builder.Services.AddScoped<IActivityLogRepository, ActivityLogRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseActivityLogging();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    await AdminInitializer.InitializeAdminAccount(app.Services, logger);
}

app.Run();