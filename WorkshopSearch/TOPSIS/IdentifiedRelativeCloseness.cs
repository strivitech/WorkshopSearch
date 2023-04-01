namespace TOPSIS;

public class IdentifiedRelativeCloseness<TIdentifier>
{
    public TIdentifier Identifier { get; }

    public double RelativeCloseness { get; }

    public IdentifiedRelativeCloseness(TIdentifier identifier, double relativeCloseness)
    {
        Identifier = identifier;
        RelativeCloseness = relativeCloseness;
    }
}