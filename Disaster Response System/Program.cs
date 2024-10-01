using Disaster_Response_System.Data;
using Disaster_Response_System.Mappings;
using Disaster_Response_System.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injecting DB Context
builder.Services.AddDbContext<DisasterResponseSystemDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DisasterResponseSystemDBContext")));

// Inject our Repositories
builder.Services.AddScoped<IDonationRepository, SQLDonationRepository>();
builder.Services.AddScoped<IDonorRepository, SQLDonorRepository>();
builder.Services.AddScoped<IRoundRepository, SQLRoundRepository>();

// Inject our automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply the CORS policy
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
