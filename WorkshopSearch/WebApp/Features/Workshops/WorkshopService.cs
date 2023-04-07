using Microsoft.EntityFrameworkCore;
using WebApp.Database.Main;

namespace WebApp.Features.Workshops;

public class WorkshopService : IWorkshopService
{
    private readonly IWorkshopExpressionBuilder _expressionBuilder;
    private readonly ApplicationDbContext _dbContext;

    public WorkshopService(IWorkshopExpressionBuilder expressionBuilder, ApplicationDbContext dbContext)
    {
        _expressionBuilder = expressionBuilder;
        _dbContext = dbContext;
    }
    
    public async Task<IList<ShortWorkshopResponse>> GetByFilterAsync(WorkshopFilter filter)
    {
        var query = _expressionBuilder.BuildQuery(filter);
        var workshops = await _dbContext.Workshops
            .Include(x => x.Directions)
            .Where(query)
            .ToListAsync();
        return workshops.ToShortWorkshopResponse();
    }
}