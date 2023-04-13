using ErrorOr;

namespace WebApp.Features.Workshops;

public interface IWorkshopService
{
    Task<ErrorOr<WorkshopResponse>> GetByIdAsync(Guid id);

    Task<ErrorOr<List<ShortWorkshopResponse>>> GetByFilterAsync(WorkshopFilter filter);
    
    Task<ErrorOr<List<ShortWorkshopResponse>>> GetByDecisionMakingAnalysisAsync(WorkshopFilter filter);
}