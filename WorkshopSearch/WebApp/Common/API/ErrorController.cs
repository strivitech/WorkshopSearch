using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Common.API;

/// <summary>
/// Error controller that is used to handle all unhandled exceptions.
/// </summary>
public class ErrorController : ControllerBase
{
    /// <summary>
    /// Handles all unhandled exceptions.
    /// </summary>
    /// <returns>An instance for <see cref="IActionResult"/>.</returns>
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return Problem(statusCode: StatusCodes.Status500InternalServerError,
            detail: "An unexpected error occurred while processing your request.");
    }
}