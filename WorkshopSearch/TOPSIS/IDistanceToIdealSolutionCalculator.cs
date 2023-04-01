namespace TOPSIS;

internal interface IDistanceToIdealSolutionCalculator
{
    List<double> GetDistancesToPositiveIdealSolution();
    List<double> GetDistancesToNegativeIdealSolution();
}