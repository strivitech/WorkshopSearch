using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApp.Database.Main;
using ErrorOr;
using WebApp.Common.Application;
using WebApp.Common.DTO;

namespace WebApp.Features.Workshops;

public class WorkshopService : IWorkshopService
{
    private readonly IWorkshopsDecisionMakingAnalysisService _workshopsDecisionMakingAnalysisService;
    private readonly IWorkshopFilterExpressionBuilder _filterExpressionBuilder;
    private readonly IWorkshopsTextSearcher _workshopsTextSearcher;
    private readonly ApplicationDbContext _dbContext;

    public WorkshopService(
        IWorkshopsDecisionMakingAnalysisService workshopsDecisionMakingAnalysisService,
        IWorkshopFilterExpressionBuilder filterExpressionBuilder,
        IWorkshopsTextSearcher workshopsTextSearcher,
        ApplicationDbContext dbContext)
    {
        _workshopsDecisionMakingAnalysisService = workshopsDecisionMakingAnalysisService;
        _filterExpressionBuilder = filterExpressionBuilder;
        _workshopsTextSearcher = workshopsTextSearcher;
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<WorkshopResponse>> GetByIdAsync(Guid id)
    {
        var workshop = await _dbContext.Workshops
            .Include(x => x.Directions)
            .FirstOrDefaultAsync(x => x.Id == new WorkshopId(id));

        return workshop is null
            ? Errors.Workshops.NotFound
            : workshop.ToWorkshopResponse();
    }

    public async Task<ErrorOr<PaginatedResponse<ShortWorkshopResponse>>> GetByFilterAsync(WorkshopFilter filter)
    {
        try
        {
            var expression = await BuildExpression(filter);

            var workshopsQuery = _dbContext.Workshops
                .Include(x => x.Directions)
                .Where(expression)
                .Skip((filter.From - 1) * filter.Size)
                .Take(filter.Size);

            var workshops =
                await PagedList<Workshop>.CreateAsync(workshopsQuery, filter.From, filter.Size);

            return workshops.ToPaginatedShortWorkshopResponse();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Errors.Workshops.GetByFilterFailure;
        }
    }

    public async Task<ErrorOr<PaginatedResponse<ShortWorkshopResponse>>> GetByDecisionMakingAnalysisAsync(
        WorkshopFilter filter)
    {
        try
        {
            var analysisModels = await GetWorkshopsAsync(filter);
            if (!analysisModels.Any())
            {
                return new PaginatedResponse<ShortWorkshopResponse>(
                    new List<ShortWorkshopResponse>(), 0, filter.Size, 0);
            }

            var workshopsCount = analysisModels.Count;

            var ordering = await _workshopsDecisionMakingAnalysisService.OrderAnalysisModelsAsync(analysisModels);
            if (ordering.IsError)
            {
                return Errors.Workshops.GetByDecisionMakingAnalysisFailure;
            }

            var filteredIds = ordering.Value
                .Skip((filter.From - 1) * filter.Size)
                .Take(filter.Size)
                .Select((id, index) => new { Id = id, OrderIndex = index })
                .ToDictionary(x => x.Id, x => x.OrderIndex);

            var workshops = await GetByIds(filteredIds.Keys);

            CheckIfWorkshopCountCorrect();
            var orderedWorkshopsByIds = OrderWorkshopsByIds();
            return new PaginatedResponse<ShortWorkshopResponse>(orderedWorkshopsByIds, filter.From, filter.Size,
                workshopsCount.CalculateTotalPages(filter.Size));

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
            return Errors.Workshops.GetByDecisionMakingAnalysisFailure;
        }
    }
    
    private async Task<Expression<Func<Workshop, bool>>> BuildExpression(WorkshopFilter filter)
    {
        Expression<Func<Workshop, bool>> buildExpression;

        if (filter.Text is not null)
        {
            var idsToSearch = await _workshopsTextSearcher.FindIdsAsync(
                new TextSearcherFilter(
                    filter.CategoryId!.Value,
                    filter.RegionWithCity.Region,
                    filter.RegionWithCity.City,
                    filter.Text));

            var filterWithoutTextSearch = new WorkshopWithoutTextSearchFilter(
                idsToSearch,
                filter.MinAge,
                filter.MaxAge,
                filter.MinPrice,
                filter.MaxPrice,
                filter.WorkingDays);

            buildExpression = _filterExpressionBuilder.BuildExpression(filterWithoutTextSearch);
        }
        else
        {
            buildExpression = _filterExpressionBuilder.BuildExpression(filter);
        }

        return buildExpression;
    }

    private async Task<List<ShortWorkshopResponse>> GetByIds(IEnumerable<Guid> ids)
    {
        var workshops = await _dbContext.Workshops
            .Where(x => ids.Select(id => new WorkshopId(id)).Contains(x.Id))
            .ToListAsync();

        return workshops.ToShortWorkshopResponse();
    }

    private async Task<List<WorkshopAnalysisModel>> GetWorkshopsAsync(WorkshopFilter filter)
    {
        var expression = await BuildExpression(filter);
        var workshops = await _dbContext.Workshops
            .Include(x => x.Directions)
            .Where(expression)
            .Select(x => new WorkshopAnalysisModel(x.Id.Value, x.Constrains.MinAge,
                x.Constrains.MaxAge, x.Constrains.Price, x.Constrains.DaysCount, x.Rating, x.ReviewsCount,
                x.EnrollmentStatus))
            .ToListAsync();

        return workshops;
    }
}