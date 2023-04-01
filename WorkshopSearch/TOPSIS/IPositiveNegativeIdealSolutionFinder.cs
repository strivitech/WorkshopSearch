namespace TOPSIS;

internal interface IPositiveNegativeIdealSolutionFinder
{
    List<double> GetPositiveIdealSolutions();
    List<double> GetNegativeIdealSolutions();
}