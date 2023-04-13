using Microsoft.AspNetCore.Mvc;
using WebApp.Common.API;

namespace WebApp.Features.Workshops;

[ApiController]
[Route(ControllersRouteConstants.DefaultRestRoute)]
public class WorkshopsController : ControllerBase
{
    private readonly IWorkshopService _workshopService;

    public WorkshopsController(IWorkshopService workshopService)
    {
        _workshopService = workshopService;
    }

    [HttpGet]
    public async Task<IActionResult> GetByDecisionMakingAnalysis([FromQuery] WorkshopFilter filter)
    {
        var workshops = await _workshopService.GetByDecisionMakingAnalysisAsync(filter);
        return workshops.MatchFirst<IActionResult>(
            Ok, 
            onError => BadRequest(onError.Description));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var workshop = await _workshopService.GetByIdAsync(id);
        return workshop.MatchFirst<IActionResult>(
            Ok, 
            onError => BadRequest(onError.Description));
    }
}