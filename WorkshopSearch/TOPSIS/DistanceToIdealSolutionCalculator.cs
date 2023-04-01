namespace TOPSIS;

internal sealed class DistanceToIdealSolutionCalculator<TIdentifier> : IDistanceToIdealSolutionCalculator
{
    private readonly IEnumerable<Alternative<TIdentifier>> _alternatives;
    private readonly IReadOnlyList<double> _positiveIdealSolutions;
    private readonly IReadOnlyList<double> _negativeIdealSolutions;

    public DistanceToIdealSolutionCalculator(IEnumerable<Alternative<TIdentifier>> alternatives, IReadOnlyList<double> positiveIdealSolutions,
        IReadOnlyList<double> negativeIdealSolutions)
    {
        _alternatives = alternatives;
        _positiveIdealSolutions = positiveIdealSolutions;
        _negativeIdealSolutions = negativeIdealSolutions;
    }

    public List<double> GetDistancesToPositiveIdealSolution() => _alternatives
        .Select(alternative => GetDistanceFrom(alternative, _positiveIdealSolutions)).ToList();
    
    public List<double> GetDistancesToNegativeIdealSolution() => _alternatives
        .Select(alternative => GetDistanceFrom(alternative, _negativeIdealSolutions)).ToList();

    private static double GetDistanceFrom(Alternative<TIdentifier> alternative, IReadOnlyList<double> idealSolutions)
    {
        var sumOfSquares = alternative.Values
            .Select((t, i) => (t - idealSolutions[i]) * (t - idealSolutions[i]))
            .Sum();
        return Math.Sqrt(sumOfSquares);
    }
}