using Disaster_Response_System.Data;
using Disaster_Response_System.Extensions;
using Disaster_Response_System.Mappings;
using Disaster_Response_System.Repositories;
using Disaster_Response_System.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injecting DB Context with Lazy Loading Proxies
builder.Services.AddDbContext<DisasterResponseSystemDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DisasterResponseSystemDBContext"))
           .UseLazyLoadingProxies());


// Inject our Generic Repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Inject our Services
builder.Services.AddScoped<IRoundService, RoundService>();
builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IRequestService, RequestService>();

// Inject our automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

// CORS: configurable via Cors__AllowedOrigins env var.
// Falls back to localhost for local dev if not set.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy
            .WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [])
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Swagger is enabled in all environments so it is reachable on deployed hosts.
app.UseSwagger();
app.UseSwaggerUI();

// HTTPS redirection is only needed when running the app directly (local dev).
// In containers, TLS is terminated at Traefik, so redirecting here would break requests.
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Apply the CORS policy
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

// Apply EF Core migrations on startup so the DB schema is created automatically.
app.MigrateDatabase();

app.Run();
