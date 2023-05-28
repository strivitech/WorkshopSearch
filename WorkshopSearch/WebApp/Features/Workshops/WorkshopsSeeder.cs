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

        if (!applicationDbContext.Workshops.Any())
        {
            applicationDbContext.Workshops.AddRange(Workshops(applicationDbContext));
            applicationDbContext.SaveChanges();
        }
    }

    private static IEnumerable<Workshop> Workshops(ApplicationDbContext applicationDbContext)
    {
        if (!applicationDbContext.Directions.Any())
        {
            throw new InvalidOperationException("Directions must be seeded before workshops");
        }

        var directions = applicationDbContext.Directions.ToList();

        return new List<Workshop>
        {
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Розробка веб-додатків на React.js",
                ContactInformation = new ContactInfo
                (
                    Email: "webdev@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/webdev",
                        "https://www.instagram.com/webdev"
                    },
                    PhoneNumber: "+380950000000"
                ),
                Constrains = new WorkshopConstrains(
                    MinAge: 10,
                    MaxAge: 60,
                    Price: 2500,
                    Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Коцюбинського",
                    BuildingNumber: "82"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1531482615713-2afd69097998?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                    "https://images.unsplash.com/photo-1659301254614-8d6a9d46f26a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                    "https://images.unsplash.com/photo-1552664688-cf412ec27db2?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80"
                },
                Description =
                    "Курс з розробки веб-додатків на React.js для початківців. Ви дізнаєтеся, як створювати модерні веб-інтерфейси з використанням одного з найпопулярніших фреймворків на ринку.",
                Owner = "WebDev School",
                Rating = 4.8f,
                ReviewsCount = 8,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction>
                {
                    directions[0]
                },
                CoverImageUri =
                    "https://images.unsplash.com/photo-1531482615713-2afd69097998?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Програмування на Python",
                ContactInformation = new ContactInfo
                (
                    Email: "workshop@example.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/workshop",
                        "https://www.instagram.com/workshop"
                    },
                    PhoneNumber: "+380000000000"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 8,
                    MaxAge: 18,
                    Price: 2000,
                    Days: DaysBitMask.Monday | DaysBitMask.Tuesday | DaysBitMask.Wednesday | DaysBitMask.Thursday |
                          DaysBitMask.Friday,
                    DaysCount: 5
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Івана Франка",
                    BuildingNumber: "1"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1531497258014-b5736f376b1b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80",
                    "https://images.unsplash.com/photo-1542626991-cbc4e32524cc?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=869&q=80",
                    "https://images.unsplash.com/photo-1557426272-fc759fdf7a8d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
                },
                Description = "Опис: На цьому курсі ви навчитеся програмувати на мові Python.",
                Owner = "Власник: Іванов Іван",
                Rating = 4.8f,
                ReviewsCount = 6,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction>
                {
                    directions[0]
                },
                CoverImageUri =
                    "https://images.unsplash.com/photo-1531497258014-b5736f376b1b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Курс .Net: Розробка веб-додатків на C#",
                ContactInformation = new ContactInfo
                (
                    Email: "dotnetcourse@gmail.com",
                    ContactLinks: new List<string>
                        { "https://www.facebook.com/dotnetcourse", "https://www.instagram.com/dotnetcourse" },
                    PhoneNumber: "+380000000009"
                ),
                Constrains = new WorkshopConstrains(
                    MinAge: 12,
                    MaxAge: 65,
                    Price: 4500,
                    Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday | DaysBitMask.Saturday,
                    DaysCount: 4
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Бульварно-Кудрявська",
                    BuildingNumber: "1"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1559526323-cb2f2fe2591b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                    "https://images.unsplash.com/photo-1576595580361-90a855b84b20?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80",
                    "https://images.unsplash.com/photo-1598520106830-8c45c2035460?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80"
                },
                Description =
                    "Курс призначений для початківців, які мають бажання навчитися розробляти веб-додатки на C# та використовувати платформу .Net для створення масштабованих та безпечних додатків. Під час курсу студенти навчаться розробляти веб-додатки з використанням ASP.Net Core, Entity Framework Core та Azure. Також будуть розглянуті практичні завдання, що допоможуть зрозуміти теорію та застосувати її на практиці.",
                Owner = "Компанія ITPro",
                Rating = 4.0f,
                ReviewsCount = 3,
                EnrollmentStatus = EnrollmentStatus.Closed,
                Directions = new List<Direction> { directions[0] },
                CoverImageUri =
                    "https://images.unsplash.com/photo-1559526323-cb2f2fe2591b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Програмування на платформі .NET",
                ContactInformation = new ContactInfo
                (
                    Email: "networkshop@gmail.com",
                    ContactLinks: new List<string>
                        { "https://www.facebook.com/networkshop", "https://www.instagram.com/networkshop" },
                    PhoneNumber: "+380000000009"
                ),
                Constrains = new WorkshopConstrains(
                    MinAge: 14,
                    MaxAge: 65,
                    Price: 1500,
                    Days: DaysBitMask.Monday | DaysBitMask.Tuesday | DaysBitMask.Wednesday | DaysBitMask.Thursday |
                          DaysBitMask.Friday,
                    DaysCount: 5
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Шевченка",
                    BuildingNumber: "16"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1494322296366-b46227baa318?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NDh8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60",
                    "https://images.unsplash.com/photo-1550439062-609e1531270e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                    "https://images.unsplash.com/photo-1454165804606-c3d57bc86b40?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
                },
                Description =
                    "Курс Програмування на платформі .NET призначений для тих, хто бажає розширити свої знання в галузі програмування. Курс надасть учасникам базові знання в програмуванні, а також допоможе збільшити рівень знань в даній сфері. Після проходження курсу учасники отримають сертифікат.",
                Owner = "Network Workshop",
                Rating = 4.9f,
                ReviewsCount = 5,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[0] },
                CoverImageUri =
                    "https://images.unsplash.com/photo-1494322296366-b46227baa318?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NDh8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Веб-розробка на мові Python",
                ContactInformation = new ContactInfo
                (
                    Email: "webdevpython@gmail.com",
                    ContactLinks: new List<string>
                        { "https://www.facebook.com/webdevpython", "https://www.instagram.com/webdevpython" },
                    PhoneNumber: "+380000000009"
                ),
                Constrains = new WorkshopConstrains(
                    MinAge: 6,
                    MaxAge: 18,
                    Price: 1000,
                    Days: DaysBitMask.Thursday | DaysBitMask.Friday | DaysBitMask.Saturday | DaysBitMask.Sunday,
                    DaysCount: 4
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Хрещатик",
                    BuildingNumber: "1"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1541178735493-479c1a27ed24?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mzl8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60",
                    "https://images.unsplash.com/photo-1434030216411-0b793f4b4173?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                    "https://images.unsplash.com/photo-1503551723145-6c040742065b-v2?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
                },
                Description =
                    "Курс з веб-розробки на мові Python допоможе вам створити власний веб-сайт, розібратися у фреймворках Flask та Django, а також дізнатися про розробку API на Python.",
                Owner = "WebDevPython",
                Rating = 1.5f,
                ReviewsCount = 3,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[0] },
                CoverImageUri =
                    "https://images.unsplash.com/photo-1541178735493-479c1a27ed24?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mzl8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Вступ до машинного навчання",
                ContactInformation = new ContactInfo
                (
                    Email: "info@ml-workshop.com",
                    ContactLinks: new List<string>
                        { "https://www.facebook.com/ml-workshop", "https://www.instagram.com/ml-workshop" },
                    PhoneNumber: "+380000000000"
                ),
                Constrains = new WorkshopConstrains(
                    MinAge: 12,
                    MaxAge: 50,
                    Price: 2000,
                    Days: DaysBitMask.Monday | DaysBitMask.Tuesday | DaysBitMask.Wednesday | DaysBitMask.Thursday |
                          DaysBitMask.Friday,
                    DaysCount: 5
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Машинобудівна",
                    BuildingNumber: "24"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1532618793091-ec5fe9635fbd?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NDB8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60",
                    "https://images.unsplash.com/photo-1517048676732-d65bc937f952?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                    "https://images.unsplash.com/photo-1623652653308-d49d335c92eb?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=869&q=80"
                },
                Description =
                    "У курсі \"Вступ до машинного навчання\" ви дізнаєтесь про основи машинного навчання, його застосування в реальних задачах та вивчите найпопулярніші бібліотеки машинного навчання в середовищі Python. Курс буде цікавим для всіх, хто бажає ознайомитись зі світом машинного навчання, але не має достатньої підготовки в цій галузі.",
                Owner = "ML Workshop",
                Rating = 2.5f,
                ReviewsCount = 2,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[0] },
                CoverImageUri =
                    "https://images.unsplash.com/photo-1532618793091-ec5fe9635fbd?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NDB8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Програмування на Python",
                ContactInformation = new ContactInfo
                (
                    Email: "python.workshop@gmail.com",
                    ContactLinks: new List<string>
                        { "https://www.facebook.com/python.workshop", "https://www.instagram.com/python.workshop" },
                    PhoneNumber: "+380000000009"
                ),
                Constrains = new WorkshopConstrains(
                    MinAge: 6,
                    MaxAge: 18,
                    Price: 1500,
                    Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Хрещатик",
                    BuildingNumber: "1"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1534665482403-a909d0d97c67?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NTF8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60",
                    "https://images.unsplash.com/photo-1552581234-26160f608093?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                    "https://images.unsplash.com/photo-1519389950473-47ba0277781c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
                },
                Description =
                    "У курсі \"Програмування на Python\" ви дізнаєтесь про засади програмування на мові Python, яка використовується в багатьох галузях, таких як веб-розробка, машинне навчання, обробка даних та інше. Курс розрахований на початківців, але матиме корисну інформацію і для досвідчених програмістів.",
                Owner = "Python School",
                Rating = 0,
                ReviewsCount = 0,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[0] },
                CoverImageUri =
                    "https://images.unsplash.com/photo-1534665482403-a909d0d97c67?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NTF8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Розробка веб-додатків з використанням JavaScript",
                ContactInformation = new ContactInfo
                (
                    Email: "webdev@js-workshop.com",
                    ContactLinks: new List<string>
                        { "https://www.facebook.com/js-workshop", "https://www.instagram.com/js-workshop" },
                    PhoneNumber: "+380000000000"
                ),
                Constrains = new WorkshopConstrains(
                    MinAge: 14,
                    MaxAge: 60,
                    Price: 1500,
                    Days: DaysBitMask.Monday | DaysBitMask.Tuesday | DaysBitMask.Wednesday | DaysBitMask.Thursday |
                          DaysBitMask.Friday,
                    DaysCount: 5
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Машинобудівна",
                    BuildingNumber: "1"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1487724077104-5196c4e819fa?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NTJ8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60",
                    "https://images.unsplash.com/photo-1620206299258-ac415ce0f7d3?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                    "https://images.unsplash.com/photo-1620326079720-500ba364af6a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80"
                },
                Description =
                    "Курс з веб-розробки на JavaScript розрахований на початківців і тих, хто вже має деякий досвід в програмуванні на JavaScript. У ході курсу ви дізнаєтеся про засади розробки веб-додатків на JavaScript, фреймворки та інші інструменти, необхідні для створення сучасних веб-додатків.",
                Owner = "JS Workshop",
                Rating = 0f,
                ReviewsCount = 0,
                EnrollmentStatus = EnrollmentStatus.Closed,
                Directions = new List<Direction> { directions[0] },
                CoverImageUri =
                    "https://images.unsplash.com/photo-1487724077104-5196c4e819fa?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NTJ8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Веб-розробка на PHP",
                ContactInformation = new ContactInfo
                (
                    Email: "webdev@gmail.com",
                    ContactLinks: new List<string>
                        { "https://www.facebook.com/webdev", "https://www.instagram.com/webdev" },
                    PhoneNumber: "+380000000001"
                ),
                Constrains = new WorkshopConstrains(
                    MinAge: 10,
                    MaxAge: 60,
                    Price: 1500,
                    Days: DaysBitMask.Monday | DaysBitMask.Tuesday | DaysBitMask.Wednesday | DaysBitMask.Thursday,
                    DaysCount: 4
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Коцюбинського",
                    BuildingNumber: "10"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1531536871726-00b05fd4a644?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NjB8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60",
                    "https://images.unsplash.com/photo-1552581466-ac9fec8dd978?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80",
                    "https://images.unsplash.com/photo-1603975711481-18b7aaca4caa?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=580&q=80"
                },
                Description =
                    "Курс з веб-розробки на мові програмування PHP. Ви дізнаєтесь про створення веб-сайтів, розробку бекенду, підключення баз даних, роботу з фреймворками і багато іншого!",
                Owner = "WebDev Inc.",
                Rating = 0f,
                ReviewsCount = 0,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[0] },
                CoverImageUri =
                    "https://images.unsplash.com/photo-1531536871726-00b05fd4a644?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NjB8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Художня майстерня",
                ContactInformation = new ContactInfo
                (
                    Email: "artisticworkshop1@gmail.com",
                    ContactLinks: new List<string>
                        { "https://www.facebook.com/artisticworkshop1", "https://www.instagram.com/artisticworkshop1" },
                    PhoneNumber: "+380000000021"
                ),
                Constrains = new WorkshopConstrains(
                    MinAge: 5,
                    MaxAge: 18,
                    Price: 500,
                    Days: DaysBitMask.Monday | DaysBitMask.Tuesday | DaysBitMask.Wednesday | DaysBitMask.Thursday |
                          DaysBitMask.Friday,
                    DaysCount: 5
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця художників",
                    BuildingNumber: "1"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1579965342575-16428a7c8881?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=462&q=80"
                },
                Description =
                    "Художній гурток, зосереджений на розвитку художньої креативності і техніки малювання. Тут ви пізнаєте основи композиції, працюєте з різними матеріалами, вивчаєте живопис та графіку, а також розвиваєте власний унікальний стиль!",
                Owner = "Artistic Workshop Inc.",
                Rating = 5f,
                ReviewsCount = 7,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri =
                    "https://images.unsplash.com/photo-1579965342575-16428a7c8881?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=462&q=80"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Творча Академія",
                ContactInformation = new ContactInfo
                (
                    Email: "creativeacademy@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/creativeacademy",
                        "https://www.instagram.com/creativeacademy"
                    },
                    PhoneNumber: "+380000000022"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 6,
                    MaxAge: 16,
                    Price: 700,
                    Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Творчості",
                    BuildingNumber: "10"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1510832842230-87253f48d74f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                },
                Description =
                    "Творча Академія запрошує молодих художників віком від 6 до 16 років на захоплюючі заняття з малювання та скульптури. Ви дізнаєтеся про різні техніки творчості, працюватимете з різноманітними матеріалами та розвиватимете свою творчу уяву!",
                Owner = "Creative Academy Ltd.",
                Rating = 4.2f,
                ReviewsCount = 12,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1510832842230-87253f48d74f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "АртСтудія",
                ContactInformation = new ContactInfo
                (
                    Email: "artstudio@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/artstudio",
                        "https://www.instagram.com/artstudio"
                    },
                    PhoneNumber: "+380000000023"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 7,
                    MaxAge: 14,
                    Price: 600,
                    Days: DaysBitMask.Tuesday | DaysBitMask.Thursday,
                    DaysCount: 2
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Мистецтва",
                    BuildingNumber: "5"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1456086272160-b28b0645b729?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1032&q=80"
                },
                Description =
                    "АртСтудія запрошує юних художників віком від 7 до 14 років на цікаві заняття з різних мистецьких напрямків. Ви дізнаєтеся про живопис, графіку, а також зможете спробувати свої сили в скульптурі та колажі. Розвивайте свої таланти разом з нами!",
                Owner = "ArtStudio LLC",
                Rating = 4.8f,
                ReviewsCount = 9,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1456086272160-b28b0645b729?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1032&q=80"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Творчі руки",
                ContactInformation = new ContactInfo
                (
                    Email: "creativehands@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/creativehands",
                        "https://www.instagram.com/creativehands"
                    },
                    PhoneNumber: "+380000000024"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 6,
                    MaxAge: 12,
                    Price: 400,
                    Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Художників",
                    BuildingNumber: "15"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1541961017774-22349e4a1262?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=758&q=80"
                },
                Description =
                    "Творчі руки - гурток для дітей віком від 6 до 12 років, де вони зможуть відкрити для себе незабутній світ малювання. Ми навчимо дітей основам живопису, використовувати різні матеріали та техніки. Приєднуйтесь до нас і розвивайте свій талант разом з нами!",
                Owner = "CreativeHands Art Studio",
                Rating = 4.5f,
                ReviewsCount = 10,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1541961017774-22349e4a1262?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=758&q=80"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Майстерня Кольорів",
                ContactInformation = new ContactInfo
                (
                    Email: "colorworkshop@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/colorworkshop",
                        "https://www.instagram.com/colorworkshop"
                    },
                    PhoneNumber: "+380000000025"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 8,
                    MaxAge: 16,
                    Price: 550,
                    Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Живопису",
                    BuildingNumber: "8"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1549289524-06cf8837ace5?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                },
                Description =
                    "Майстерня Кольорів запрошує молодих художників віком від 8 до 16 років на захоплюючі заняття з живопису та кольорознавства. Ми розвиватимемо ваші навички малювання, допоможемо розкрити ваш творчий потенціал та навчимо вас використовувати кольори для створення виразних картин. Приєднуйтесь до нас і зануртесь у світ мистецтва!",
                Owner = "ColorWorks Art Studio",
                Rating = 4.2f,
                ReviewsCount = 8,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1549289524-06cf8837ace5?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Колоритний Світ",
                ContactInformation = new ContactInfo
                (
                    Email: "colorfulworld@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/colorfulworld",
                        "https://www.instagram.com/colorfulworld"
                    },
                    PhoneNumber: "+380000000027"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 7,
                    MaxAge: 15,
                    Price: 600,
                    Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Художника",
                    BuildingNumber: "7"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1525909002-1b05e0c869d8?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8cGFpbnRpbmd8ZW58MHx8MHx8fDI%3D&auto=format&fit=crop&w=1000&q=60"
                },
                Description =
                    "Колоритний Світ - гурток, що запрошує молодих художників віком від 7 до 15 років на захоплюючі заняття з малювання. У нашій майстерні ви навчитеся використовувати кольори, створювати гармонійні композиції та розвиватимете свої художні навички. Приєднуйтеся до нас та розкрийте свої таланти в Колоритному Світі!",
                Owner = "Colorful World Art Studio",
                Rating = 4.6f,
                ReviewsCount = 11,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1525909002-1b05e0c869d8?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8cGFpbnRpbmd8ZW58MHx8MHx8fDI%3D&auto=format&fit=crop&w=1000&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Магія Пензля",
                ContactInformation = new ContactInfo
                (
                    Email: "brushmagic@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/brushmagic",
                        "https://www.instagram.com/brushmagic"
                    },
                    PhoneNumber: "+380000000028"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 9,
                    MaxAge: 17,
                    Price: 800,
                    Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday | DaysBitMask.Saturday,
                    DaysCount: 4
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Мистецтва",
                    BuildingNumber: "15"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1515405295579-ba7b45403062?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8cGFpbnRpbmd8ZW58MHx8MHx8fDI%3D&auto=format&fit=crop&w=1000&q=60"
                },
                Description =
                    "Магія Пензля - гурток, що пропонує молодим художникам віком від 9 до 17 років досліджувати та відтворювати магію малюнка. Наші заняття допоможуть вам розвинути навички малювання, працювати з різними матеріалами та створювати власні шедеври. Приєднуйтесь до нашої Магії Пензля та відкрийте світ мистецтва!",
                Owner = "Brush Magic Art Studio",
                Rating = 4.9f,
                ReviewsCount = 15,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1515405295579-ba7b45403062?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8cGFpbnRpbmd8ZW58MHx8MHx8fDI%3D&auto=format&fit=crop&w=1000&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Фантастичні Пейзажі",
                ContactInformation = new ContactInfo
                (
                    Email: "fantasticlandscapes@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/fantasticlandscapes",
                        "https://www.instagram.com/fantasticlandscapes"
                    },
                    PhoneNumber: "+380000000029"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 8,
                    MaxAge: 14,
                    Price: 550,
                    Days: DaysBitMask.Tuesday | DaysBitMask.Thursday,
                    DaysCount: 2
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Пейзажу",
                    BuildingNumber: "6"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1579783928621-7a13d66a62d1?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
                },
                Description =
                    "Фантастичні Пейзажі - гурток для дітей віком від 8 до 14 років, де вони зможуть втілити у життя неймовірні пейзажі зі своєї уяви. Ми розвиватимемо ваші навички малювання природи, допоможемо вам створити фантастичні світи та розкрити ваш творчий потенціал. Приходьте до нас і зануртесь у світ Фантастичних Пейзажів!",
                Owner = "Fantastic Landscapes Art Studio",
                Rating = 4.7f,
                ReviewsCount = 9,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1579783928621-7a13d66a62d1?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Творча Палітра",
                ContactInformation = new ContactInfo
                (
                    Email: "creativepalette@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/creativepalette",
                        "https://www.instagram.com/creativepalette"
                    },
                    PhoneNumber: "+380000000032"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 6,
                    MaxAge: 12,
                    Price: 450,
                    Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Майстрів",
                    BuildingNumber: "9"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1531913764164-f85c52e6e654?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
                },
                Description =
                    "Творча Палітра - гурток для дітей віком від 6 до 12 років, де вони зможуть відкрити для себе безкрайні можливості малювання. Ми навчимо дітей різноманітним технікам, допоможемо розвивати їх художній стиль та створювати унікальні шедеври. Приєднуйтеся до нас та розкрийте свої таланти в Творчій Палітрі!",
                Owner = "Creative Palette Art Studio",
                Rating = 4.3f,
                ReviewsCount = 7,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1531913764164-f85c52e6e654?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Майстерня Малюнка",
                ContactInformation = new ContactInfo
                (
                    Email: "artworkshop@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/artworkshop",
                        "https://www.instagram.com/artworkshop"
                    },
                    PhoneNumber: "+380000000033"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 7,
                    MaxAge: 14,
                    Price: 550,
                    Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Мистецтва",
                    BuildingNumber: "15"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1461344577544-4e5dc9487184?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
                },
                Description =
                    "Майстерня Малюнка - гурток для дітей віком від 7 до 14 років, де вони зможуть розвинути свою художню творчість та навички малювання. Ми навчимо дітей різним стилям та технікам малювання, розкриємо їхню уяву та допоможемо створити унікальні малюнки. Приєднуйтеся до нас та відкрийте світ Майстерні Малюнка!",
                Owner = "Art Workshop",
                Rating = 4.7f,
                ReviewsCount = 9,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1461344577544-4e5dc9487184?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Креативний Пензель",
                ContactInformation = new ContactInfo
                (
                    Email: "creativebrush@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/creativebrush",
                        "https://www.instagram.com/creativebrush"
                    },
                    PhoneNumber: "+380000000034"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 8,
                    MaxAge: 16,
                    Price: 650,
                    Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Художників",
                    BuildingNumber: "10"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1520420097861-e4959843b682?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
                },
                Description =
                    "Креативний Пензель - гурток для молодих художників віком від 8 до 16 років, де вони зможуть розкрити свою креативність та навички роботи з пензлем. Ми навчимо дітей різним технікам малювання, допоможемо виявити їхній особистий стиль та створити вражаючі шедеври. Приєднуйтеся до нашого Креативного Пензля та розкрийте свій творчий потенціал!",
                Owner = "Creative Brush Art Studio",
                Rating = 4.5f,
                ReviewsCount = 8,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1520420097861-e4959843b682?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Творчий Квест",
                ContactInformation = new ContactInfo
                (
                    Email: "creativequest@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/creativequest",
                        "https://www.instagram.com/creativequest"
                    },
                    PhoneNumber: "+380000000035"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 6,
                    MaxAge: 14,
                    Price: 500,
                    Days: DaysBitMask.Wednesday | DaysBitMask.Friday,
                    DaysCount: 2
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Творчості",
                    BuildingNumber: "7"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1541753866388-0b3c701627d3?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
                },
                Description =
                    "Творчий Квест - гурток, що запрошує дітей віком від 6 до 14 років на захоплюючі пригоди з малювання. Ми проведемо вас через квест, де ви дізнаєтесь різні техніки малювання, розвинете свою творчу уяву та створите власні шедеври. Приєднуйтесь до нашого Творчого Квесту та відкрийте новий світ мистецтва!",
                Owner = "Creative Quest Art Studio",
                Rating = 4.4f,
                ReviewsCount = 10,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1541753866388-0b3c701627d3?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Магічні Фарби",
                ContactInformation = new ContactInfo
                (
                    Email: "magicpaints@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/magicpaints",
                        "https://www.instagram.com/magicpaints"
                    },
                    PhoneNumber: "+380000000036"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 7,
                    MaxAge: 16,
                    Price: 600,
                    Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday | DaysBitMask.Saturday,
                    DaysCount: 4
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Мистецтва",
                    BuildingNumber: "12"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1460661419201-fd4cecdf8a8b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
                },
                Description =
                    "Магічні Фарби - гурток для молодих художників віком від 7 до 16 років, де ви зможете зануритися у світ магії фарб. Ми навчимо вас різним технікам малювання, допоможемо виявити ваш творчий потенціал та створити вражаючі малюнки. Приєднуйтесь до нашого гуртка Магічних Фарб та перетворіть ваші ідеї на реальність!",
                Owner = "Magic Paints Art Studio",
                Rating = 4.8f,
                ReviewsCount = 13,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1460661419201-fd4cecdf8a8b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Художній Талант",
                ContactInformation = new ContactInfo
                (
                    Email: "arttalent@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/arttalent",
                        "https://www.instagram.com/arttalent"
                    },
                    PhoneNumber: "+380000000037"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 8,
                    MaxAge: 15,
                    Price: 550,
                    Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Мистецького Таланту",
                    BuildingNumber: "8"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/flagged/photo-1567934150921-7632371abb32?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
                },
                Description =
                    "Художній Талант - гурток, що розкриває творчі здібності дітей віком від 8 до 15 років. Ми допомагаємо нашим учасникам розвивати навички малювання, вдосконалювати художній стиль та створювати вражаючі твори мистецтва. Приєднуйтеся до нашого гуртка Художнього Таланту та виявіть свій потенціал!",
                Owner = "Art Talent Art Studio",
                Rating = 4.6f,
                ReviewsCount = 11,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/flagged/photo-1567934150921-7632371abb32?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Мистецькі Візії",
                ContactInformation = new ContactInfo
                (
                    Email: "artvisions@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/artvisions",
                        "https://www.instagram.com/artvisions"
                    },
                    PhoneNumber: "+380000000038"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 6,
                    MaxAge: 12,
                    Price: 450,
                    Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Творчих Мрій",
                    BuildingNumber: "11"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1615339725569-80172615f345?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
                },
                Description =
                    "Мистецькі Візії - гурток для дітей віком від 6 до 12 років, де вони зможуть розвивати свою творчу уяву та відкривати нові мистецькі горизонти. Ми навчимо дітей різним технікам малювання, допоможемо виявити їхні унікальні таланти та створити чарівні шедеври. Приєднуйтесь до нас у Мистецькі Візії!",
                Owner = "Art Visions Art Studio",
                Rating = 4.3f,
                ReviewsCount = 9,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1615339725569-80172615f345?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Творчий Експеримент",
                ContactInformation = new ContactInfo
                (
                    Email: "creativeexperiment@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/creativeexperiment",
                        "https://www.instagram.com/creativeexperiment"
                    },
                    PhoneNumber: "+380000000039"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 7,
                    MaxAge: 14,
                    Price: 550,
                    Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Творчих Експериментів",
                    BuildingNumber: "9"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1531489956451-20957fab52f2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
                },
                Description =
                    "Творчий Експеримент - гурток для молодих художників віком від 7 до 14 років, де вони зможуть експериментувати з мистецтвом та розкривати свою творчість. Ми допоможемо дітям розвивати навички малювання, навчити їх новим технікам та втілювати унікальні ідеї. Приєднуйтесь до нашого Творчого Експерименту!",
                Owner = "Creative Experiment Art Studio",
                Rating = 4.7f,
                ReviewsCount = 11,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1531489956451-20957fab52f2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=1000&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Арт-Терапія",
                ContactInformation = new ContactInfo
                (
                    Email: "arttherapy@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/arttherapy",
                        "https://www.instagram.com/arttherapy"
                    },
                    PhoneNumber: "+380000000040"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 10,
                    MaxAge: 18,
                    Price: 700,
                    Days: DaysBitMask.Wednesday | DaysBitMask.Friday | DaysBitMask.Saturday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Мистецької Терапії",
                    BuildingNumber: "6"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1613746203812-717e6e5db3da?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjZ8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=500&q=60"
                },
                Description =
                    "Арт-Терапія - гурток, що поєднує мистецтво та терапевтичні підходи для молодих людей віком від 10 до 18 років. Через малювання та творчість, ми допомагаємо учасникам знайти внутрішню гармонію, виразити свої емоції та знайти внутрішню силу. Приєднуйтесь до нашого гуртка Арт-Терапії та відкрийте нові можливості!",
                Owner = "Art Therapy Art Studio",
                Rating = 4.9f,
                ReviewsCount = 15,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1613746203812-717e6e5db3da?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjZ8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=500&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Творчі Пензлі",
                ContactInformation = new ContactInfo
                (
                    Email: "creativebrushes@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/creativebrushes",
                        "https://www.instagram.com/creativebrushes"
                    },
                    PhoneNumber: "+380000000041"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 7,
                    MaxAge: 15,
                    Price: 550,
                    Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Творчих Пензлів",
                    BuildingNumber: "14"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1553949345-eb786bb3f7ba?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjV8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=500&q=60"
                },
                Description =
                    "Творчі Пензлі - гурток для молодих художників віком від 7 до 15 років, де вони зможуть розвивати свої навички малювання та виражати свою творчість. Ми навчимо учасників різним технікам та стилістикам малювання, допоможемо відкрити нові горизонти у світі мистецтва. Приєднуйтеся до нашого гуртка Творчих Пензлів!",
                Owner = "Creative Brushes Art Studio",
                Rating = 4.7f,
                ReviewsCount = 12,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1553949345-eb786bb3f7ba?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjV8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=500&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Майстерня Колорит",
                ContactInformation = new ContactInfo
                (
                    Email: "colorworkshop@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/colorworkshop",
                        "https://www.instagram.com/colorworkshop"
                    },
                    PhoneNumber: "+380000000042"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 8,
                    MaxAge: 16,
                    Price: 600,
                    Days: DaysBitMask.Monday | DaysBitMask.Wednesday | DaysBitMask.Friday | DaysBitMask.Saturday,
                    DaysCount: 4
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Майстерні Колориту",
                    BuildingNumber: "7"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1605721911519-3dfeb3be25e7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mjl8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=500&q=60"
                },
                Description =
                    "Майстерня Колорит - гурток для творчих особистостей віком від 8 до 16 років, де вони зможуть вивчити різні техніки малювання та виразити свої почуття кольором. Ми навчимо учасників експериментувати з палітрою, відкривати нові глибини в мистецтві та втілювати свої ідеї на полотні. Приєднуйтеся до Майстерні Колориту!",
                Owner = "Color Workshop Art Studio",
                Rating = 4.9f,
                ReviewsCount = 13,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1605721911519-3dfeb3be25e7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mjl8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=500&q=60"
            },
            new()
            {
                Id = new WorkshopId(Guid.NewGuid()),
                Title = "Художня Імпреза",
                ContactInformation = new ContactInfo
                (
                    Email: "artparty@gmail.com",
                    ContactLinks: new List<string>
                    {
                        "https://www.facebook.com/artparty",
                        "https://www.instagram.com/artparty"
                    },
                    PhoneNumber: "+380000000043"
                ),
                Constrains = new WorkshopConstrains
                (
                    MinAge: 6,
                    MaxAge: 12,
                    Price: 500,
                    Days: DaysBitMask.Tuesday | DaysBitMask.Thursday | DaysBitMask.Saturday,
                    DaysCount: 3
                ),
                Address = new Address
                (
                    Region: "Київ",
                    City: "Київ",
                    Street: "Вулиця Художньої Імпрези",
                    BuildingNumber: "10"
                ),
                ImageUris = new List<string>
                {
                    "https://images.unsplash.com/photo-1543857778-c4a1a3e0b2eb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MzF8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=500&q=60"
                },
                Description =
                    "Художня Імпреза - гурток, який поєднує мистецтво та веселу атмосферу вечірки для дітей віком від 6 до 12 років. Ми навчимо учасників творити чудеса на полотні, розвивати уяву та сприяти їхньому творчому самовираженню. Приєднуйтеся до Художньої Імпрези!",
                Owner = "Art Party Art Studio",
                Rating = 4.5f,
                ReviewsCount = 10,
                EnrollmentStatus = EnrollmentStatus.Open,
                Directions = new List<Direction> { directions[2] },
                CoverImageUri = "https://images.unsplash.com/photo-1543857778-c4a1a3e0b2eb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MzF8fHBhaW50aW5nfGVufDB8fDB8fHwy&auto=format&fit=crop&w=500&q=60"
            }
        };
    }
}