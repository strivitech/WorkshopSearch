using ErrorOr;
using WebApp.Common.DTO;

namespace WebApp.Features.Workshops;

public interface IWorkshopService
{
    Task<ErrorOr<WorkshopResponse>> GetByIdAsync(Guid id);

    Task<ErrorOr<PaginatedResponse<ShortWorkshopResponse>>> GetByFilterAsync(WorkshopFilter filter);
    
    Task<ErrorOr<PaginatedResponse<ShortWorkshopResponse>>> GetByDecisionMakingAnalysisAsync(WorkshopFilter filter);
}