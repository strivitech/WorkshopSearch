namespace WebApp.Features.Workshops;

public static class ToShortWorkshopResponseMapper
{
    public static ShortWorkshopResponse ToShortWorkshopResponse(this Workshop workshop)
    {
        return new ShortWorkshopResponse
        {
            Id = workshop.Id.Value,
            Title = workshop.Title,
            Owner = workshop.Owner,
            MinAge = workshop.Constrains.MinAge,
            MaxAge = workshop.Constrains.MaxAge,
            Price = workshop.Constrains.Price,
            Address = workshop.Address,
            CoverImageUri = workshop.CoverImageUri,
        };
    }

    public static List<ShortWorkshopResponse> ToShortWorkshopResponse(this IEnumerable<Workshop> workshops) =>
        workshops.Select(ToShortWorkshopResponse).ToList();
}