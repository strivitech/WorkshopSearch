namespace TOPSIS;

internal sealed class PositiveNegativeIdealSolutionFinder<TIdentifier> : IPositiveNegativeIdealSolutionFinder
{
    private readonly IEnumerable<Alternative<TIdentifier>> _alternatives;
    private readonly IReadOnlyList<Direction> _directions;
    private readonly int _numberOfCriteria;

    public PositiveNegativeIdealSolutionFinder(IEnumerable<Alternative<TIdentifier>> alternatives, IReadOnlyList<Direction> directions)
    {
        _alternatives = alternatives;
        _numberOfCriteria = _alternatives.First().Values.Count;
        _directions = directions;
    }
    
    // TODO: maybe rewrite these methods
    public List<double> GetPositiveIdealSolutions()
    {
        return Enumerable.Range(0, _numberOfCriteria)
            .Select((_, i) => _alternatives.Select(alternative => alternative.Values[i]))
            .Select((values, i) => _directions[i].Value == DirectionValue.Maximize
                ? values.Max()
                : values.Min())
            .ToList();
    }
    
    public List<double> GetNegativeIdealSolutions()
    {
        return Enumerable.Range(0, _numberOfCriteria)
            .Select((_, i) => _alternatives.Select(alternative => alternative.Values[i]))
            .Select((values, i) => _directions[i].Value == DirectionValue.Maximize
                ? values.Min()
                : values.Max())
            .ToList();
    }
}