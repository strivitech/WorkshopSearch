namespace TOPSIS;

public interface IWorkingTableAlternatives<TIdentifier>
{
    WorkingTable<TIdentifier> AddAlternative(Alternative<TIdentifier> alternative);

    WorkingTable<TIdentifier> AddAlternatives(ICollection<Alternative<TIdentifier>> alternatives);
}