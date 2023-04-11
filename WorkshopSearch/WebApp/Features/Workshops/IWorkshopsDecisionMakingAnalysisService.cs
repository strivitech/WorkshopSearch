namespace WebApp.Features.Workshops;

public interface IWorkshopsDecisionMakingAnalysisService
{
    Task<List<Guid>> OrderAnalysisModelsAsync(IEnumerable<WorkshopAnalysisModel> workshopAnalysisModels);
}