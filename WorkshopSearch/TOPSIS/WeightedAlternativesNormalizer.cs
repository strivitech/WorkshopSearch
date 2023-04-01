namespace TOPSIS;

internal sealed class WeightedAlternativesNormalizer<TIdentifier> : IWeightedAlternativesNormalizer<TIdentifier>
{
    private readonly IAlternativesNormalizer<TIdentifier> _normalizer;
    private readonly IReadOnlyList<Weight> _weights;

    public WeightedAlternativesNormalizer(IAlternativesNormalizer<TIdentifier> normalizer, IReadOnlyList<Weight> weights)
    {
        _normalizer = normalizer;
        _weights = weights;
    }

    public List<Alternative<TIdentifier>> GetNormalizedAlternatives()
    {
        var normalizedAlternatives = _normalizer.GetNormalizedAlternatives();
        return normalizedAlternatives.Select(alternative =>
            new Alternative<TIdentifier>(alternative.Identifier, GetWeightedForEach(alternative))).ToList();

        List<double> GetWeightedForEach(Alternative<TIdentifier> alternative)
            => alternative.Values.Select((t, i) => t * _weights[i].Value).ToList();
    }
}