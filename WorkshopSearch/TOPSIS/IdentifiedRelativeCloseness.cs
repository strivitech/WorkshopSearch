namespace TOPSIS;

public class IdentifiedRelativeCloseness<TIdentifier>
{
    public TIdentifier Identifier { get; }

    public double RelativeCloseness { get; }

    internal IdentifiedRelativeCloseness(TIdentifier identifier, double relativeCloseness)
    {
        Identifier = identifier;
        RelativeCloseness = relativeCloseness;
    }
}