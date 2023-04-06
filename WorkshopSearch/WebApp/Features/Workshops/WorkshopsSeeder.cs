using WebApp.Database.Main;
using WebApp.Features.Directions;

namespace WebApp.Features.Workshops;

public static class WorkshopsSeeder
{
    public static void AddWorkshops(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (!applicationDbContext.Directions.Any())
        {
            throw new InvalidOperationException("Directions must be seeded before workshops");
        }

        if (!applicationDbContext.Workshops.Any())
        {
            var directions = applicationDbContext.Directions.ToList();
            applicationDbContext.Workshops.AddRange(Workshops(directions));
            applicationDbContext.SaveChanges();
        }
    }

    private static IEnumerable<Workshop> Workshops(List<Direction> directions) => new List<Workshop>
    {
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 1",
            ContactInformation = new ContactInfo
            (
                Email: "workshop1@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop1", "https://www.instagram.com/workshop1" },
                PhoneNumber: "+380000000001"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 1,
                MaxAge: 99,
                Price: 100
            ),
            Address = "Address 1",
            ImageUris = new List<string>
                { "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png" },
            Description = "Description 1",
            Owner = "Owner 1",
            Directions = new List<Direction> { directions[0], directions[1] }
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 2",
            ContactInformation = new ContactInfo
            (
                Email: "workshop2@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop2", "https://www.instagram.com/workshop2" },
                PhoneNumber: "+380000000002"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 10,
                MaxAge: 60,
                Price: 150
            ),
            Address = "Address 2",
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop2.jpg" },
            Description = "Description 2",
            Owner = "Owner 2",
            Directions = new List<Direction> { directions[0], directions[1], directions[2] }
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 3",
            ContactInformation = new ContactInfo
            (
                Email: "workshop3@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop3", "https://www.instagram.com/workshop3" },
                PhoneNumber: "+380000000003"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 18,
                MaxAge: 30,
                Price: 200
            ),
            Address = "Address 3",
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop3.jpg" },
            Description = "Description 3",
            Owner = "Owner 3",
            Directions = new List<Direction> { directions[0] }
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 4",
            ContactInformation = new ContactInfo
            (
                Email: "workshop4@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop4", "https://www.instagram.com/workshop4" },
                PhoneNumber: "+380000000004"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 12,
                MaxAge: 50,
                Price: 250
            ),
            Address = "Address 4",
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop4.jpg" },
            Description = "Description 4",
            Owner = "Owner 4",
            Directions = new List<Direction> { directions[0] }
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 5",
            ContactInformation = new ContactInfo
            (
                Email: "workshop5@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop5", "https://www.instagram.com/workshop5" },
                PhoneNumber: "+380000000005"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 15,
                MaxAge: 70,
                Price: 300
            ),
            Address = "Address 5",
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop5.jpg" },
            Description = "Description 5",
            Owner = "Owner 5",
            Directions = new List<Direction> { directions[2] }
        },
    };
}