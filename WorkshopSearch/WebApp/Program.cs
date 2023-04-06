using System.Diagnostics;
using System.Text.Json;
using WebApp;
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