namespace TOPSIS;

internal class IdentifiedDistanceScope<TIdentifier>
{
    public TIdentifier Identifier { get; }
    
    public double DistanceToPositiveSolution { get; }
    
    public double DistanceToNegativeSolution { get; }

    public IdentifiedDistanceScope(TIdentifier identifier, double distanceToPositiveSolution, double distanceToNegativeSolution)
    {
        Identifier = identifier;
        DistanceToPositiveSolution = distanceToPositiveSolution;
        DistanceToNegativeSolution = distanceToNegativeSolution;
    }
}