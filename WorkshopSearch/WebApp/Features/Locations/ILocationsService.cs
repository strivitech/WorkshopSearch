namespace WebApp.Features.Locations;

public interface ILocationsService
{
    Task<List<LocationResponse>> GetBySearchTermAsync(string searchTerm);
}