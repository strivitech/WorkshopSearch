using Microsoft.AspNetCore.Mvc;
using WebApp.Common.API;

namespace WebApp.Features.Locations;

[ApiController]
[Route(ControllersRouteConstants.DefaultRestRoute)]
public class LocationsController : ControllerBase
{
    private readonly ILocationsService _locationsService;

    public LocationsController(ILocationsService locationsService)
    {
        _locationsService = locationsService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByWord([FromQuery] string word)
    {
        var locations = await _locationsService.GetBySearchTermAsync(word);
        return locations.Any()
            ? Ok(locations)
            : NoContent();
    }
}