using Microsoft.EntityFrameworkCore;
using WebApp.Database.Main;
using WebApp.Elasticsearch;
using WebApp.Features.Directions;
using WebApp.Features.Locations;
using WebApp.Features.Workshops;

namespace WebApp;

/// <summary>
/// Contains methods to set up essential dependencies and pipelines.
/// </summary>
public static class Startup
{
    /// <summary>
    /// Configures services for the application.
    /// </summary>
    /// <param name="builder">Web Application builder.</param>
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
        
        builder.Services.AddSwaggerGen();

        services.AddDbContext<ApplicationDbContext>(options =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IWorkshopFilterExpressionBuilder, WorkshopFilterExpressionBuilder>();
        services.AddScoped<IWorkshopService, WorkshopService>();
        services.AddScoped<IWorkshopsDecisionMakingAnalysisService, WorkshopsDecisionMakingAnalysisService>();
        services.AddScoped<WorkshopAnalysisMetadata>();
        services.AddScoped<IDirectionsService, DirectionsService>();
        
        services.Configure<ElasticsearchSettings>(configuration.GetSection("Elasticsearch"));
        services.AddSingleton<IElasticsearchService, ElasticsearchService>();
        services.AddScoped<ILocationIndexInitializer, LocationIndexInitializer>();
        services.AddHostedService<ElasticsearchIndexHostedService>();
        services.AddSingleton<LocationSeeder>();
        services.AddScoped<ILocationsService, LocationsService>();
        services.AddScoped<IWorkshopIndexInitializer, WorkshopIndexInitializer>();
        services.AddScoped<WorkshopEsSeeder>();
        services.AddScoped<IWorkshopsTextSearcher, WorkshopsTextSearcher>();
    }

    /// <summary>
    /// Configures the middleware pipeline for the application.
    /// </summary>
    /// <param name="app">Web Application.</param>
    public static void Configure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseExceptionHandler("/error");

        app.UseHttpsRedirection();
        
        app.UseStaticFiles();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapFallbackToFile("index.html");
    }
}
