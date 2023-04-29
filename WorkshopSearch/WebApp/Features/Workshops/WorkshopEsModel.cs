namespace WebApp.Features.Workshops;

public class WorkshopEsModel
{
    public Guid Id { get; set; }
    
    public string Region { get; set; } = null!;
    
    public string City { get; set; } = null!;
    
    public string Title { get; set; } = null!;
    
    public string Description { get; set; } = null!;
}