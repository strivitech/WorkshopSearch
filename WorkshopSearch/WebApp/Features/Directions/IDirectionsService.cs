namespace WebApp.Features.Directions;

public interface IDirectionsService
{
    Task<List<DirectionDto>> GetAllAsync();
}