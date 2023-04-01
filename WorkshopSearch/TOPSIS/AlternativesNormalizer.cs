namespace TOPSIS;

internal sealed class AlternativesNormalizer<TIdentifier> : IAlternativesNormalizer<TIdentifier>
{
    private readonly IEnumerable<Alternative<TIdentifier>> _alternatives;

    public AlternativesNormalizer(IEnumerable<Alternative<TIdentifier>> alternatives)
    {
        _alternatives = alternatives;
    }

    public List<Alternative<TIdentifier>> GetNormalizedAlternatives()
    {
        var sqrtOfSumSquaresByCriteria = GetSqrtOfSumSquaresByCriteria();
        return _alternatives.Select(alternative => new Alternative<TIdentifier>(alternative.Identifier, GetNormalizedForEach(alternative))).ToList();

        List<double> GetNormalizedForEach(Alternative<TIdentifier> alternative)
            => alternative.Values.Select((t, i) => t / sqrtOfSumSquaresByCriteria[i]).ToList();
    }

    private List<double> GetSqrtOfSumSquaresByCriteria()
    {
        var sumOfSquaresList = Enumerable.Repeat(0.0, 5).ToList();
        var criteriaCount = _alternatives.First().Values.Count;
        
        foreach (var alternative in _alternatives)
        {
            for (var i = 0; i < criteriaCount; i++)
            {
                sumOfSquaresList[i] += alternative.Values[i] * alternative.Values[i];
            }
        }
        
        return sumOfSquaresList.Select(Math.Sqrt).ToList();
    }
}