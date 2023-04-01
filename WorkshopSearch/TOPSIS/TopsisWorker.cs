namespace TOPSIS;

public class TopsisWorker<TIdentifier>
{
    private readonly WorkingTable<TIdentifier> _workingTable;

    public TopsisWorker(WorkingTable<TIdentifier> workingTable)
    {
        _workingTable = workingTable;
    }

    public List<IdentifiedRelativeCloseness<TIdentifier>> GetRelativeClosenessToIdealSolution()
    {
        var weightedNormalizedAlternatives = GetWeightedNormalizedAlternatives();
        var idealSolutionFinder = GetPositiveIdealSolutionFinder(weightedNormalizedAlternatives);
        
        var positiveIdealSolutionList = GetPositiveIdealSolution(idealSolutionFinder);
        var negativeIdealSolutionList = GetNegativeIdealSolution(idealSolutionFinder);
        
        var distanceScopes = GetDistanceScopes(
            weightedNormalizedAlternatives,
            positiveIdealSolutionList,
            negativeIdealSolutionList
        );

        return distanceScopes.CalculateProximity();
    }

    private List<Alternative<TIdentifier>> GetWeightedNormalizedAlternatives()
    {
        var normalizer = new WeightedAlternativesNormalizer<TIdentifier>(
            new AlternativesNormalizer<TIdentifier>(_workingTable.Alternatives),
            _workingTable.Weights
        );

        return normalizer.GetNormalizedAlternatives();
    }

    private IPositiveNegativeIdealSolutionFinder GetPositiveIdealSolutionFinder(List<Alternative<TIdentifier>> alternatives)
    {
        return new PositiveNegativeIdealSolutionFinder<TIdentifier>(
            alternatives,
            _workingTable.Directions
        );
    }
    
    private static List<IdentifiedDistanceScope<TIdentifier>> GetDistanceScopes(
        List<Alternative<TIdentifier>> alternatives,
        List<double> positiveIdealSolutionList,
        List<double> negativeIdealSolutionList
    )
    {
        var distanceCalculator = new DistanceToIdealSolutionCalculator<TIdentifier>(
            alternatives,
            positiveIdealSolutionList,
            negativeIdealSolutionList
            );
        
        var distancesToPositiveIdealSolution = distanceCalculator.GetDistancesToPositiveIdealSolution();
        var distancesToNegativeIdealSolution = distanceCalculator.GetDistancesToNegativeIdealSolution();

        return alternatives
            .Select((alternative, i) => new IdentifiedDistanceScope<TIdentifier>(
                alternative.Identifier,
                distancesToPositiveIdealSolution[i],
                distancesToNegativeIdealSolution[i]
            ))
            .ToList();
    }

    private static List<double> GetPositiveIdealSolution(IPositiveNegativeIdealSolutionFinder finder) 
        => finder.GetPositiveIdealSolutions();
    
    private static List<double> GetNegativeIdealSolution(IPositiveNegativeIdealSolutionFinder finder)
        => finder.GetNegativeIdealSolutions();
}