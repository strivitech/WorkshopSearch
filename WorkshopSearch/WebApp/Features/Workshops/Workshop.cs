using WebApp.Common.Data.Entities;
using WebApp.Features.Directions;

namespace WebApp.Features.Workshops;

public record WorkshopId(Guid Value);

public class Workshop : BaseEntity<WorkshopId>
{
    public string Title { get; set; } = null!;
    public ContactInfo ContactInformation { get; set; } = null!;
    public WorkshopConstrains Constrains { get; set; } = null!;
    public string Address { get; set; } = null!;
    public List<string> ImageUris { get; set; } = null!;
    public List<Direction> Directions{ get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Owner { get; set; } = null!;
    public string CoverImageUri { get; set; } = null!;
}