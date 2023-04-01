using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace TOPSIS;

public class WorkingTable<TIdentifier>
{
    private readonly ObservableCollection<Alternative<TIdentifier>> _observableAlternatives = new();

    public IReadOnlyList<Criteria> Criteria { get; }

    public IReadOnlyList<Direction> Directions { get; }

    public IReadOnlyList<Weight> Weights { get; }
    
    public IReadOnlyList<Alternative<TIdentifier>> Alternatives { get; private set; } =
        new List<Alternative<TIdentifier>>().AsReadOnly();

    private WorkingTable(IEnumerable<Criteria> criteria, IEnumerable<Direction> directions, IEnumerable<Weight> weights)
    {
        Criteria = criteria.ToList().AsReadOnly();
        Directions = directions.ToList().AsReadOnly();
        Weights = weights.ToList().AsReadOnly();
        _observableAlternatives.CollectionChanged += OnAlternativesChanged;
    }

    public WorkingTable<TIdentifier> AddAlternative(Alternative<TIdentifier> alternative)
    {
        ValidateAlternative(alternative, Criteria.Count);
        _observableAlternatives.Add(alternative);
        return this;
    }

    public WorkingTable<TIdentifier> AddAlternatives(ICollection<Alternative<TIdentifier>> alternatives)
    {
        foreach (var alternative in alternatives)
        {
            ValidateAlternative(alternative, Criteria.Count);
        }
        _observableAlternatives.AddRange(alternatives);
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
            _workingTable._observableAlternatives.Add(alternative);
            return _workingTable;
        }

        public WorkingTable<TIdentifier> AddAlternatives(ICollection<Alternative<TIdentifier>> alternatives)
        {
            foreach (var alternative in alternatives)
            {
                ValidateAlternative(alternative, _workingTable.Criteria.Count);
            }
            _workingTable._observableAlternatives.AddRange(alternatives);
            return _workingTable;
        }
    }

    private void OnAlternativesChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        Alternatives = _observableAlternatives.AsReadOnly();
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