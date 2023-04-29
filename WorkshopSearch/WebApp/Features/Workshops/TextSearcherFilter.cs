namespace WebApp.Features.Workshops;

public class TextSearcherFilter
{
    public int CategoryId { get; set; }
    
    public string Region { get; set; } = null!;
    
    public string City { get; set; } = null!;
    
    public string Text { get; set; } = null!;
}