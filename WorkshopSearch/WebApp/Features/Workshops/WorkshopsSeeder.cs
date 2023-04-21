using WebApp.Common.Data;
using WebApp.Common.Data.ValueObjects;
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
                Price: 100,
                Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 1",
                BuildingNumber: "1"
            ),
            ImageUris = new List<string>
                { "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png" },
            Description = "Description 1",
            Owner = "Owner 1",
            Rating = 4.5f,
            ReviewsCount = 10,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[0], directions[1] },
            CoverImageUri = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png"
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
                Price: 150,
                Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 2",
                BuildingNumber: "2"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop2.jpg" },
            Description = "Description 2",
            Owner = "Owner 2",
            Rating = 3.5f,
            ReviewsCount = 5,
            EnrollmentStatus = EnrollmentStatus.Closed,
            Directions = new List<Direction> { directions[0], directions[1], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop2.jpg"
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
                Price: 200,
                Days: DaysBitMask.Sunday,
                DaysCount: 1
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 3",
                BuildingNumber: "3"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop3.jpg" },
            Description = "Description 3",
            Owner = "Owner 3",
            Rating = 5f,
            ReviewsCount = 1,
            EnrollmentStatus = EnrollmentStatus.Closed,
            Directions = new List<Direction> { directions[0] },
            CoverImageUri = "https://www.example.com/images/workshop3.jpg"
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
                Price: 250,
                Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 4",
                BuildingNumber: "4"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop4.jpg" },
            Description = "Description 4",
            Owner = "Owner 4",
            Rating = 4f,
            ReviewsCount = 2,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[0] },
            CoverImageUri = "https://www.example.com/images/workshop4.jpg"
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
                Price: 0,
                Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 5",
                BuildingNumber: "5"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop5.jpg" },
            Description = "Description 5",
            Owner = "Owner 5",
            Rating = 3f,
            ReviewsCount = 3,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop5.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 6",
            ContactInformation = new ContactInfo
            (
                Email: "workshop6@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop6", "https://www.instagram.com/workshop6" },
                PhoneNumber: "+380000000006"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 16,
                MaxAge: 65,
                Price: 300,
                Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 6",
                BuildingNumber: "6"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop6.jpg" },
            Description = "Description 6",
            Owner = "Owner 6",
            Rating = 4.2f,
            ReviewsCount = 8,
            EnrollmentStatus = EnrollmentStatus.Closed,
            Directions = new List<Direction> { directions[1], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop6.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 7",
            ContactInformation = new ContactInfo
            (
                Email: "workshop7@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop7", "https://www.instagram.com/workshop7" },
                PhoneNumber: "+380000000007"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 20,
                MaxAge: 40,
                Price: 350,
                Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 7",
                BuildingNumber: "7"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop7.jpg" },
            Description = "Description 7",
            Owner = "Owner 7",
            Rating = 4.7f,
            ReviewsCount = 15,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[0], directions[1], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop7.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 8",
            ContactInformation = new ContactInfo
            (
                Email: "workshop8@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop8", "https://www.instagram.com/workshop8" },
                PhoneNumber: "+380000000008"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 18,
                MaxAge: 55,
                Price: 400,
                Days: DaysBitMask.Tuesday | DaysBitMask.Thursday,
                DaysCount: 2
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 8",
                BuildingNumber: "8"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop8.jpg" },
            Description = "Description 8",
            Owner = "Owner 8",
            Rating = 3.9f,
            ReviewsCount = 12,
            EnrollmentStatus = EnrollmentStatus.Closed,
            Directions = new List<Direction> { directions[1], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop8.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 9",
            ContactInformation = new ContactInfo
            (
                Email: "workshop9@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop9", "https://www.instagram.com/workshop9" },
                PhoneNumber: "+380000000009"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 25,
                MaxAge: 50,
                Price: 450,
                Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 9",
                BuildingNumber: "9"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop9.jpg" },
            Description = "Description 9",
            Owner = "Owner 9",
            Rating = 4.3f,
            ReviewsCount = 20,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[0], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop9.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 10",
            ContactInformation = new ContactInfo
            (
                Email: "workshop10@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop10", "https://www.instagram.com/workshop10" },
                PhoneNumber: "+380000000010"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 30,
                MaxAge: 60,
                Price: 500,
                Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 10",
                BuildingNumber: "10"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop10.jpg" },
            Description = "Description 10",
            Owner = "Owner 10",
            Rating = 4.1f,
            ReviewsCount = 18,
            EnrollmentStatus = EnrollmentStatus.Closed,
            Directions = new List<Direction> { directions[0], directions[1] },
            CoverImageUri = "https://www.example.com/images/workshop10.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 11",
            ContactInformation = new ContactInfo
            (
                Email: "workshop11@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop11", "https://www.instagram.com/workshop11" },
                PhoneNumber: "+380000000011"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 18,
                MaxAge: 45,
                Price: 550,
                Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 11",
                BuildingNumber: "11"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop11.jpg" },
            Description = "Description 11",
            Owner = "Owner 11",
            Rating = 4.6f,
            ReviewsCount = 25,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[1], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop11.jpg"
        },
    };
}