using WebApp.Common.Data;
using WebApp.Features.Directions;

namespace WebApp.Features.Workshops;

public class WorkshopResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<string> ContactLinks { get; set; } = null!;
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public decimal Price { get; set; }
    public string Address { get; set; } = null!;
    public List<string>? ImageUris { get; set; }
    public List<DirectionDto> Directions { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Owner { get; set; } = null!;
    public float Rating { get; set; }
    public int ReviewsCount { get; set; }
    public string? CoverImageUri { get; set; }
    public List<string> Days { get; set; } = null!;
}