namespace WebApp.Features.Workshops;

public class WorkshopEsModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Description { get; set; } = null!;
}