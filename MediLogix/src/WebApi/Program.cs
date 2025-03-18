using AutoMapper;
using MediLogix.Application.Common.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContextFactory<MediLogixDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MediLogixDB"));
});

/*// Add this line to register the interface
builder.Services.AddScoped<IMediLogixDbContext>(provider => 
    provider.GetRequiredService<MediLogixDbContext>());*/

builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();

// Add JWT Configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MediLogixDbContext>()
    .AddDefaultTokenProviders();

// Add JWT Service
builder.Services.AddScoped<IJwtService, JwtService>();

// Add Mapping Configuration
builder.Services.AddMappings();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();