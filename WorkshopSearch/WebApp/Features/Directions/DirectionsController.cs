using Microsoft.AspNetCore.Mvc;
using WebApp.Common.API;

namespace WebApp.Features.Directions;

[ApiController]
[Route(ControllersRouteConstants.DefaultRestRoute)]
public class DirectionsController : ControllerBase
{
    private readonly IDirectionsService _directionsService;

    public DirectionsController(IDirectionsService directionsService)
    {
        _directionsService = directionsService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var directions = await _directionsService.GetAllAsync();
        return directions.Any()
            ? Ok(directions)
            : NoContent();
    }
}