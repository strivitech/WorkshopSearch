using WebApp;
using WebApp.Database.Main;
using WebApp.Features.Directions;
using WebApp.Features.Workshops;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.ConfigureServices();
var app = builder.Build();
app.Configure();

try
{
    // Add logs
    app.ApplyApplicationDbContextMigrations();
    app.AddDirections();
    app.AddWorkshops();

    app.Run();
}
catch (Exception ex)
{
    // Add logs
    // Debug.WriteLine(JsonSerializer.Serialize(ex));
}
finally
{
    // Add logs and flush
}