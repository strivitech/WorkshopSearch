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
                CoverImageUri = "https://images.unsplash.com/photo-1531482615713-2afd69097998?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
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
                    Days: DaysBitMask.Monday | DaysBitMask.Tuesday | DaysBitMask.Wednesday | DaysBitMask.Thursday | DaysBitMask.Friday,
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
                CoverImageUri = "https://images.unsplash.com/photo-1531497258014-b5736f376b1b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80"
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
                CoverImageUri = "https://images.unsplash.com/photo-1559526323-cb2f2fe2591b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
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
                    Days: DaysBitMask.Monday | DaysBitMask.Tuesday | DaysBitMask.Wednesday | DaysBitMask.Thursday | DaysBitMask.Friday,
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
                CoverImageUri = "https://images.unsplash.com/photo-1494322296366-b46227baa318?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NDh8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
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
                CoverImageUri = "https://images.unsplash.com/photo-1541178735493-479c1a27ed24?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mzl8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
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
                    Days: DaysBitMask.Monday | DaysBitMask.Tuesday | DaysBitMask.Wednesday | DaysBitMask.Thursday | DaysBitMask.Friday,
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
                CoverImageUri = "https://images.unsplash.com/photo-1532618793091-ec5fe9635fbd?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NDB8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
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
                CoverImageUri = "https://images.unsplash.com/photo-1534665482403-a909d0d97c67?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NTF8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
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
                    Days: DaysBitMask.Monday | DaysBitMask.Tuesday | DaysBitMask.Wednesday | DaysBitMask.Thursday | DaysBitMask.Friday,
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
                CoverImageUri = "https://images.unsplash.com/photo-1487724077104-5196c4e819fa?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NTJ8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
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
                CoverImageUri = "https://images.unsplash.com/photo-1531536871726-00b05fd4a644?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NjB8fHBlb3BsZSUyMGNvZGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
            }
        };
    }
}