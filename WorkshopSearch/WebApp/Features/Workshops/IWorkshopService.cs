namespace WebApp.Features.Workshops;

public interface IWorkshopService
{
    Task<List<ShortWorkshopResponse>> GetByFilterAsync(WorkshopFilter filter);
    
    Task<List<ShortWorkshopResponse>> GetByDecisionMakingAnalysisAsync(WorkshopFilter filter);
}