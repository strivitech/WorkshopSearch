namespace TOPSIS;

public class Criteria
{
    public string Value { get; }

    public Criteria(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }
        Value = value;
    }
}