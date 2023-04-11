namespace TOPSIS;

public interface ITopsisWorker<TIdentifier>
{
    List<IdentifiedRelativeCloseness<TIdentifier>> GetOrderingByRelativeClosenessToIdealSolution();
}