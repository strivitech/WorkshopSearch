using ErrorOr;

namespace WebApp.Features.Workshops;

public interface IWorkshopsDecisionMakingAnalysisService
{
    Task<ErrorOr<List<Guid>>> OrderAnalysisModelsAsync(IEnumerable<WorkshopAnalysisModel> workshopAnalysisModels);
}