using Disaster_Response_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Response_System.Extensions;

public static class WebApplicationExtensions
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DisasterResponseSystemDBContext>();
        db.Database.Migrate();
    }
}
