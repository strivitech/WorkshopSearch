using Microsoft.EntityFrameworkCore;
using WebApp.Database.Main;

namespace WebApp.Features.Workshops;

public class WorkshopService : IWorkshopService
{
    private readonly IWorkshopFilterExpressionBuilder _filterExpressionBuilder;
    private readonly ApplicationDbContext _dbContext;

    public WorkshopService(IWorkshopFilterExpressionBuilder filterExpressionBuilder, ApplicationDbContext dbContext)
    {
        _filterExpressionBuilder = filterExpressionBuilder;
        _dbContext = dbContext;
    }
    
    public async Task<IList<ShortWorkshopResponse>> GetByFilterAsync(WorkshopFilter filter)
    {
        var expression = _filterExpressionBuilder.BuildExpression(filter);
        var workshops = await _dbContext.Workshops
            .Include(x => x.Directions)
            .Where(expression)
            .Skip((filter.From - 1) * filter.Size)
            .Take(filter.Size)
            .ToListAsync();
        
        return workshops.ToShortWorkshopResponse();
    }
}