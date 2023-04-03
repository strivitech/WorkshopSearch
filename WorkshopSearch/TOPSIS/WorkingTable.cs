namespace TOPSIS;

public class WorkingTable<TIdentifier>
{
    private readonly List<Alternative<TIdentifier>> _alternatives = new();

    public IReadOnlyList<Criteria> Criteria { get; }

    public IReadOnlyList<Direction> Directions { get; }

    public IReadOnlyList<Weight> Weights { get; }
    
    public IReadOnlyList<Alternative<TIdentifier>> Alternatives => _alternatives.AsReadOnly();

    private WorkingTable(IEnumerable<Criteria> criteria, IEnumerable<Direction> directions, IEnumerable<Weight> weights)
    {
        Criteria = criteria.ToList().AsReadOnly();
        Directions = directions.ToList().AsReadOnly();
        Weights = weights.ToList().AsReadOnly();
    }

    public WorkingTable<TIdentifier> AddAlternative(Alternative<TIdentifier> alternative)
    {
        ValidateAlternative(alternative, Criteria.Count);
        _alternatives.Add(alternative);
        return this;
    }

    public WorkingTable<TIdentifier> AddAlternatives(ICollection<Alternative<TIdentifier>> alternatives)
    {
        foreach (var alternative in alternatives)
        {
            ValidateAlternative(alternative, Criteria.Count);
        }
        _alternatives.AddRange(alternatives);
        return this;
    }

    private class Implementation : IWorkingTableAlternatives<TIdentifier>
    {
        private readonly WorkingTable<TIdentifier> _workingTable;

        public Implementation(IEnumerable<Criteria> criteria, IEnumerable<Direction> directions,
            IEnumerable<Weight> weights)
        {
            _workingTable = new WorkingTable<TIdentifier>(criteria, directions, weights);
        }

        public WorkingTable<TIdentifier> AddAlternative(Alternative<TIdentifier> alternative)
        {
            ValidateAlternative(alternative, _workingTable.Criteria.Count);
            _workingTable._alternatives.Add(alternative);
            return _workingTable;
        }

        public WorkingTable<TIdentifier> AddAlternatives(ICollection<Alternative<TIdentifier>> alternatives)
        {
            foreach (var alternative in alternatives)
            {
                ValidateAlternative(alternative, _workingTable.Criteria.Count);
            }
            _workingTable._alternatives.AddRange(alternatives);
            return _workingTable;
        }
    }

    private static void ValidateAlternative(Alternative<TIdentifier> alternative, int criteriaCount)
    {
        if (alternative.Values.Count != criteriaCount)
        {
            throw new InvalidOperationException("Alternative has invalid number of values, based on criteria count");
        }
    }

    public static IWorkingTableAlternatives<TIdentifier> Create(ICollection<Criteria> criteria,
        ICollection<Direction> directions, ICollection<Weight> weights)
    {
        if (criteria.Count == directions.Count && directions.Count == weights.Count)
        {
            return new Implementation(criteria, directions, weights);
        }
        
        throw new ArgumentException("Invalid arguments, all collections must have the same length");
    }
}