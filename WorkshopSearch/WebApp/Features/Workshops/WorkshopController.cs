using Microsoft.AspNetCore.Mvc;
using WebApp.Common.API;

namespace WebApp.Features.Workshops;

[ApiController]
[Route(ControllersRouteConstants.DefaultControllerActionRoute)]
public class WorkshopController : ControllerBase
{
    private readonly IWorkshopService _workshopService;

    public WorkshopController(IWorkshopService workshopService)
    {
        _workshopService = workshopService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByFilter([FromQuery] WorkshopFilter filter)
    {
        var workshops = await _workshopService.GetByFilterAsync(filter);
        return Ok(workshops);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByDecisionMakingAnalysis([FromQuery] WorkshopFilter filter)
    {
        var workshops = await _workshopService.GetByDecisionMakingAnalysisAsync(filter);
        return Ok(workshops);
    }
}