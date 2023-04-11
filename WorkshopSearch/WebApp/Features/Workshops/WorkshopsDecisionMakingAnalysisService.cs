using TOPSIS;

namespace WebApp.Features.Workshops;

public class WorkshopsDecisionMakingAnalysisService : IWorkshopsDecisionMakingAnalysisService
{
    private readonly WorkshopAnalysisMetadata _workshopAnalysisMetadata;

    public WorkshopsDecisionMakingAnalysisService(WorkshopAnalysisMetadata workshopAnalysisMetadata)
    {
        _workshopAnalysisMetadata = workshopAnalysisMetadata;
    }

    public async Task<List<Guid>> OrderAnalysisModelsAsync(IEnumerable<WorkshopAnalysisModel> workshopAnalysisModels)
    {
        var workingTable = GetWorkingTable(workshopAnalysisModels);
        var topsisWorker = new TopsisWorker<Guid>(workingTable);

        var ordering = await Task.Run(() => topsisWorker.GetOrderingByRelativeClosenessToIdealSolution()
            .Select(x => x.Identifier)
            .ToList());

        return ordering;
    }

    private WorkingTable<Guid> GetWorkingTable(IEnumerable<WorkshopAnalysisModel> workshopAnalysisModels)
    {
        var workingTable = WorkingTable<Guid>.Create(
                _workshopAnalysisMetadata.GetCriteria,
                _workshopAnalysisMetadata.GetDirections,
                _workshopAnalysisMetadata.GetWeights)
            .AddAlternatives(workshopAnalysisModels.Select(wam =>
                new Alternative<Guid>(wam.Id, new List<double>
                {
                    wam.MinAge,
                    wam.MaxAge,
                    wam.DaysCount,
                    (double)wam.Price,
                    wam.Rating,
                    wam.ReviewsCount,
                    ConvertEnrollmentStatus(wam.EnrollmentStatus)
                })).ToArray());

        return workingTable;

        double ConvertEnrollmentStatus(EnrollmentStatus enrollmentStatus)
        {
            return enrollmentStatus switch
            {
                EnrollmentStatus.Open => 1,
                EnrollmentStatus.Closed => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(enrollmentStatus), "Unknown enrollment status")
            };
        }
    }
}