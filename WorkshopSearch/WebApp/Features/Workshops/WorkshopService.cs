using Microsoft.EntityFrameworkCore;
using WebApp.Database.Main;
using ErrorOr;

namespace WebApp.Features.Workshops;

public class WorkshopService : IWorkshopService
{
    private readonly IWorkshopsDecisionMakingAnalysisService _workshopsDecisionMakingAnalysisService;
    private readonly IWorkshopFilterExpressionBuilder _filterExpressionBuilder;
    private readonly ApplicationDbContext _dbContext;

    public WorkshopService(
        IWorkshopsDecisionMakingAnalysisService workshopsDecisionMakingAnalysisService,
        IWorkshopFilterExpressionBuilder filterExpressionBuilder,
        ApplicationDbContext dbContext)
    {
        _workshopsDecisionMakingAnalysisService = workshopsDecisionMakingAnalysisService;
        _filterExpressionBuilder = filterExpressionBuilder;
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<List<ShortWorkshopResponse>>> GetByFilterAsync(WorkshopFilter filter)
    {
        try
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Errors.Workshops.GetByFilterFailure;
        }
    }

    public async Task<ErrorOr<List<ShortWorkshopResponse>>> GetByDecisionMakingAnalysisAsync(WorkshopFilter filter)
    {
        try
        {
            var analysisModels = await GetWorkshopsAsync(filter);
            var ordering = await _workshopsDecisionMakingAnalysisService.OrderAnalysisModelsAsync(analysisModels);
            if (ordering.IsError)
            {
                return Errors.Workshops.DecisionMakingAnalysisOrderingFailed;
            }
        
            var filteredIds = ordering.Value
                .Skip((filter.From - 1) * filter.Size)
                .Take(filter.Size)
                .Select((id, index) => new { Id = id, OrderIndex = index })
                .ToDictionary(x => x.Id, x => x.OrderIndex);

            var workshops = await GetByIds(filteredIds.Keys);

            CheckIfWorkshopCountCorrect();
            return OrderWorkshopsByIds();
            
            void CheckIfWorkshopCountCorrect()
            {
                if (filteredIds.Count != workshops.Count)
                {
                    throw new InvalidOperationException("Workshops count is not equal to filtered ids count");
                }
            }

            List<ShortWorkshopResponse> OrderWorkshopsByIds()
            {
                var orderedWorkshops = new List<ShortWorkshopResponse>(filteredIds.Count);
                orderedWorkshops.AddRange(Enumerable.Repeat<ShortWorkshopResponse>(null!, filteredIds.Count));

                workshops.ForEach(workshop => orderedWorkshops[filteredIds[workshop.Id]] = workshop);

                return orderedWorkshops;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Errors.Workshops.DecisionMakingAnalysisOrderingFailed;
        }
    }

    private async Task<List<ShortWorkshopResponse>> GetByIds(IEnumerable<Guid> ids)
    {
        var workshops = await _dbContext.Workshops
            .Include(x => x.Directions)
            .Where(x => ids.Select(id => new WorkshopId(id)).Contains(x.Id))
            .ToListAsync();

        return workshops.ToShortWorkshopResponse();
    }

    private async Task<List<WorkshopAnalysisModel>> GetWorkshopsAsync(WorkshopFilter filter)
    {
        var expression = _filterExpressionBuilder.BuildExpression(filter);
        var workshops = await _dbContext.Workshops
            .Include(x => x.Directions)
            .Where(expression)
            .Select(x => new WorkshopAnalysisModel(x.Id.Value, x.Constrains.MinAge,
                x.Constrains.MaxAge, x.Constrains.Price, x.Constrains.DaysCount, x.Rating, x.ReviewsCount, x.EnrollmentStatus))
            .ToListAsync();

        return workshops;
    }
}