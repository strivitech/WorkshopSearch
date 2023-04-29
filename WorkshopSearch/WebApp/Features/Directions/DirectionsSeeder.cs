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
    
    private static List<Direction> Directions { get; } = new List<Direction>
    {
        new()
        {
            Id = new DirectionId(1),
            Name = "IT, Програмування"
        },
        new()
        {
            Id = new DirectionId(2),
            Name = "Конструювання"
        },
        new()
        {
            Id = new DirectionId(3),
            Name = "Малювання"
        },
        new()
        {
            Id = new DirectionId(4),
            Name = "Мови/Гуманітарій"
        },
        new()
        {
            Id = new DirectionId(5),
            Name = "Музика"
        },
        new()
        {
            Id = new DirectionId(6),
            Name = "Наука та досліди"
        },
        new()
        {
            Id = new DirectionId(7),
            Name = "Оздоровлення"
        },
        new()
        {
            Id = new DirectionId(8),
            Name = "Рукоділля"
        },
        new()
        {
            Id = new DirectionId(9),
            Name = "Спорт"
        },
        new()
        {
            Id = new DirectionId(10),
            Name = "Танці"
        },
        new()
        {
            Id = new DirectionId(11),
            Name = "Інше"
        },
    };
}