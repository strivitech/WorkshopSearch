namespace TOPSIS;

internal interface IAlternativesNormalizer<TIdentifier>
{
    List<Alternative<TIdentifier>> GetNormalizedAlternatives();
}