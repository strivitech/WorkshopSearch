using Microsoft.EntityFrameworkCore;
using WebApp.Database.Main;

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
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        
        
    }

    /// <summary>
    /// Configures the middleware pipeline for the application.
    /// </summary>
    /// <param name="app">Web Application.</param>
    public static void Configure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            // app.UseSwagger();
            // app.UseSwaggerUI();
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
