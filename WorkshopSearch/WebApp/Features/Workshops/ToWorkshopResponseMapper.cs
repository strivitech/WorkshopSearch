using WebApp.Common.Data;
using WebApp.Features.Directions;

namespace WebApp.Features.Workshops;

public static class ToWorkshopResponseMapper
{
    public static WorkshopResponse ToWorkshopResponse(this Workshop workshop)
    {
        return new WorkshopResponse
        {
            Id = workshop.Id.Value,
            Title = workshop.Title,
            PhoneNumber = workshop.ContactInformation.PhoneNumber,
            Email = workshop.ContactInformation.Email,
            ContactLinks = workshop.ContactInformation.ContactLinks.ToList(),
            MinAge = workshop.Constrains.MinAge,
            MaxAge = workshop.Constrains.MaxAge,
            Price = workshop.Constrains.Price,
            Address = workshop.Address.ToString(),
            ImageUris = workshop.ImageUris.ToList(),
            Directions = workshop.Directions.Select(d => d.ToDirectionDto()).ToList(),
            Description = workshop.Description,
            Owner = workshop.Owner,
            Rating = workshop.Rating,
            ReviewsCount = workshop.ReviewsCount,
            EnrollmentStatus = workshop.EnrollmentStatus,
            CoverImageUri = workshop.CoverImageUri,
            Days = workshop.Constrains.Days.GetDaysFromBitMask()
        };
    }
}