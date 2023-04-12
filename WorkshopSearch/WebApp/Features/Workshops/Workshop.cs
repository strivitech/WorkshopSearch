using WebApp.Common.Data.Entities;
using WebApp.Common.Data.ValueObjects;
using WebApp.Features.Directions;

namespace WebApp.Features.Workshops;

public record WorkshopId(Guid Value);

public class Workshop : BaseEntity<WorkshopId>
{
    public string Title { get; set; } = null!;
    public ContactInfo ContactInformation { get; set; } = null!;
    public WorkshopConstrains Constrains { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public List<string> ImageUris { get; set; } = null!;
    public List<Direction> Directions{ get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Owner { get; set; } = null!;
    public float Rating { get; set; }
    public int ReviewsCount { get; set; }
    public EnrollmentStatus EnrollmentStatus { get; set; }
    public string CoverImageUri { get; set; } = null!;
}