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
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 12",
            ContactInformation = new ContactInfo
            (
                Email: "workshop12@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop12", "https://www.instagram.com/workshop12" },
                PhoneNumber: "+380000000012"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 18,
                MaxAge: 60,
                Price: 200,
                Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 12",
                BuildingNumber: "12"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop12.jpg" },
            Description = "Description 12",
            Owner = "Owner 12",
            Rating = 4.0f,
            ReviewsCount = 7,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[0], directions[1], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop12.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 13",
            ContactInformation = new ContactInfo
            (
                Email: "workshop13@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop13", "https://www.instagram.com/workshop13" },
                PhoneNumber: "+380000000013"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 16,
                MaxAge: 50,
                Price: 150,
                Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 13",
                BuildingNumber: "13"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop13.jpg" },
            Description = "Description 13",
            Owner = "Owner 13",
            Rating = 3.8f,
            ReviewsCount = 3,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[0], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop13.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 14",
            ContactInformation = new ContactInfo
            (
                Email: "workshop14@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop14", "https://www.instagram.com/workshop14" },
                PhoneNumber: "+380000000014"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 25,
                MaxAge: 50,
                Price: 150,
                Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 14",
                BuildingNumber: "14"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop14.jpg" },
            Description = "Description 14",
            Owner = "Owner 14",
            Rating = 4.2f,
            ReviewsCount = 8,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[0], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop14.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 15",
            ContactInformation = new ContactInfo
            (
                Email: "workshop15@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop15", "https://www.instagram.com/workshop15" },
                PhoneNumber: "+380000000015"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 20,
                MaxAge: 55,
                Price: 300,
                Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 15",
                BuildingNumber: "15"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop15.jpg" },
            Description = "Description 15",
            Owner = "Owner 15",
            Rating = 4.5f,
            ReviewsCount = 10,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[1], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop15.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 16",
            ContactInformation = new ContactInfo
            (
                Email: "workshop16@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop16", "https://www.instagram.com/workshop16" },
                PhoneNumber: "+380000000016"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 18,
                MaxAge: 65,
                Price: 350,
                Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 16",
                BuildingNumber: "16"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop16.jpg" },
            Description = "Description 16",
            Owner = "Owner 16",
            Rating = 4.7f,
            ReviewsCount = 15,
            EnrollmentStatus = EnrollmentStatus.Closed,
            Directions = new List<Direction> { directions[0], directions[1] },
            CoverImageUri = "https://www.example.com/images/workshop16.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 17",
            ContactInformation = new ContactInfo
            (
                Email: "workshop17@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop17", "https://www.instagram.com/workshop17" },
                PhoneNumber: "+380000000017"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 18,
                MaxAge: 50,
                Price: 400,
                Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 17",
                BuildingNumber: "17"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop17.jpg" },
            Description = "Description 17",
            Owner = "Owner 17",
            Rating = 4.4f,
            ReviewsCount = 14,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[1], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop17.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 18",
            ContactInformation = new ContactInfo
            (
                Email: "workshop18@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop18", "https://www.instagram.com/workshop18" },
                PhoneNumber: "+380000000018"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 21,
                MaxAge: 60,
                Price: 100,
                Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 18",
                BuildingNumber: "18"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop18.jpg" },
            Description = "Description 18",
            Owner = "Owner 18",
            Rating = 4.8f,
            ReviewsCount = 19,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[0], directions[1] },
            CoverImageUri = "https://www.example.com/images/workshop18.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 19",
            ContactInformation = new ContactInfo
            (
                Email: "workshop19@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop19", "https://www.instagram.com/workshop19" },
                PhoneNumber: "+380000000019"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 18,
                MaxAge: 55,
                Price: 300,
                Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 19",
                BuildingNumber: "19"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop19.jpg" },
            Description = "Description 19",
            Owner = "Owner 19",
            Rating = 3.7f,
            ReviewsCount = 9,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[0], directions[1], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop19.jpg"
        },
        new()
        {
            Id = new WorkshopId(Guid.NewGuid()),
            Title = "Workshop 20",
            ContactInformation = new ContactInfo
            (
                Email: "workshop20@gmail.com",
                ContactLinks: new List<string>
                    { "https://www.facebook.com/workshop20", "https://www.instagram.com/workshop20" },
                PhoneNumber: "+380000000020"
            ),
            Constrains = new WorkshopConstrains(
                MinAge: 10,
                MaxAge: 60,
                Price: 0,
                Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                DaysCount: 3
            ),
            Address = new Address
            (
                Region: "Київ",
                City: "Київ",
                Street: "Street 20",
                BuildingNumber: "20"
            ),
            ImageUris = new List<string>
                { "https://www.example.com/images/workshop20.jpg" },
            Description = "Description 20",
            Owner = "Owner 20",
            Rating = 4.5f,
            ReviewsCount = 22,
            EnrollmentStatus = EnrollmentStatus.Open,
            Directions = new List<Direction> { directions[1], directions[2] },
            CoverImageUri = "https://www.example.com/images/workshop20.jpg"
        }
    };
}