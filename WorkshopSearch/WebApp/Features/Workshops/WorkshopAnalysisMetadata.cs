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
        };

    public virtual List<Direction> GetDirections =>
        new()
        {
            new Direction(DirectionValue.Minimize),
            new Direction(DirectionValue.Maximize),
            new Direction(DirectionValue.Maximize),
            new Direction(DirectionValue.Minimize),
        };

    public virtual List<Weight> GetWeights =>
        new()
        {
            new Weight(0.05),
            new Weight(0.05),
            new Weight(0.15),
            new Weight(0.75),
        };
}