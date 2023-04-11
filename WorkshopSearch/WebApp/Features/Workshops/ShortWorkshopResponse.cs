namespace WebApp.Features.Workshops;

public class ShortWorkshopResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Owner { get; set; } = null!;
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public decimal Price { get; set; }
    public string Address { get; set; } = null!;
    
    public float Rating { get; set; }
    
    public int ReviewsCount { get; set; }
    public string CoverImageUri { get; set; } = null!;
}