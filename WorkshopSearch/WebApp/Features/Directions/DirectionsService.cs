using Microsoft.EntityFrameworkCore;
using WebApp.Database.Main;

namespace WebApp.Features.Directions;

public class DirectionsService : IDirectionsService
{
    private readonly ApplicationDbContext _dbContext;

    public DirectionsService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<DirectionDto>> GetAllAsync()
    {
        var directions = await _dbContext.Directions
            .Select(direction => new DirectionDto
            {
                Id = direction.Id.Value,
                Name = direction.Name
            })
            .ToListAsync();
        
        return directions;
    }
}