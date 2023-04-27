namespace WebApp.Features.Locations;

public interface ILocationsService
{
    Task<List<LocationEsModel>> GetBySearchTermAsync(string searchTerm);
}