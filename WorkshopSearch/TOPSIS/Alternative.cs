namespace TOPSIS;

public class Alternative<TIdentifier>
{
    public TIdentifier Identifier { get; }
    
    public List<double> Values { get; }

    public Alternative(TIdentifier identifier, List<double> values)
    {
        Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Values = values ?? throw new ArgumentNullException(nameof(values));
    }
}