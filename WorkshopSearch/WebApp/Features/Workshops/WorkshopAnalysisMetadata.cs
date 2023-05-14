using TOPSIS;

namespace WebApp.Features.Workshops;

public class WorkshopAnalysisMetadata
{
    public virtual List<Criteria> GetCriteria =>
        new()
        {
            new Criteria(nameof(WorkshopAnalysisModel.MinAge)),
            new Criteria(nameof(WorkshopAnalysisModel.MaxAge)),
            new Criteria(nameof(WorkshopAnalysisModel.DaysCount)),
            new Criteria(nameof(WorkshopAnalysisModel.Price)),
            new Criteria(nameof(WorkshopAnalysisModel.Rating)),
            new Criteria(nameof(WorkshopAnalysisModel.ReviewsCount)),
            new Criteria(nameof(WorkshopAnalysisModel.EnrollmentStatus))
        };

    public virtual List<Direction> GetDirections =>
        new()
        {
            new Direction(DirectionValue.Minimize),
            new Direction(DirectionValue.Maximize),
            new Direction(DirectionValue.Maximize),
            new Direction(DirectionValue.Minimize),
            new Direction(DirectionValue.Maximize),
            new Direction(DirectionValue.Maximize),
            new Direction(DirectionValue.Maximize)
        };

    public virtual List<Weight> GetWeights =>
        new()
        {
            new Weight(0.025),
            new Weight(0.025),
            new Weight(0.1),
            new Weight(0.2),
            new Weight(0.35),
            new Weight(0.1),
            new Weight(0.2)
        };
}