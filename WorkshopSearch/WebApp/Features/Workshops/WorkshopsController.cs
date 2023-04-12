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
        return Ok(workshops);
    }
}