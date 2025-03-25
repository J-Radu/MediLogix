var builder = WebApplication.CreateBuilder(args);

// Base services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDatabaseServices(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddApplicationServices();

// Configure authentication and authorization
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddIdentityServices();

// Register services
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddMappings();
builder.Services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddMemoryCache();
builder.Services.AddJwtBlacklist();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

// Pipeline of authentication and authorization middlewares
app.UseJwtValidation();  
app.UseAuthentication();
app.UseAuthorization();

// Logging middleware
app.UseActivityLogging();

app.MapControllers();

// Initialize admin account
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    await AdminInitializer.InitializeAdminAccount(app.Services, logger);
}

app.Run();