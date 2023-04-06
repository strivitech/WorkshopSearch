using WebApp.Database.Main;

namespace WebApp.Features.Directions;

public static class DirectionsSeeder
{
    public static void AddDirections(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (!applicationDbContext.Directions.Any())
        {
            applicationDbContext.Directions.AddRange(Directions);
            applicationDbContext.SaveChanges();
        }
    }
    
    private static IEnumerable<Direction> Directions { get; } = new List<Direction>
    {
        new()
        {
            Id = new DirectionId(1),
            Name = "Direction 1"
        },
        new()
        {
            Id = new DirectionId(2),
            Name = "Direction 2"
        },
        new()
        {
            Id = new DirectionId(3),
            Name = "Direction 3"
        },
    };
}