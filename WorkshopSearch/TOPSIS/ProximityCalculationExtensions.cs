﻿namespace TOPSIS;

internal static class ProximityCalculationExtensions
{
    public static List<IdentifiedRelativeCloseness<TIdentifier>> OrderByCalculatedProximityDesc<TIdentifier>(
        this IEnumerable<IdentifiedDistanceScope<TIdentifier>> identifiedDistanceScope)
    {
        return identifiedDistanceScope.Select(distanceScope =>
            new IdentifiedRelativeCloseness<TIdentifier>(distanceScope.Identifier,
                distanceScope.DistanceToNegativeSolution /
                (distanceScope.DistanceToPositiveSolution +
                 distanceScope.DistanceToNegativeSolution)))
            .OrderByDescending(relativeCloseness => relativeCloseness.RelativeCloseness)
            .ToList();
    }

    public static List<IdentifiedRelativeCloseness<TIdentifier>> CalculateProximity<TIdentifier>(
        this IEnumerable<IdentifiedDistanceScope<TIdentifier>> identifiedDistanceScope)
    {
        return identifiedDistanceScope.Select(distanceScope =>
            new IdentifiedRelativeCloseness<TIdentifier>(distanceScope.Identifier,
                distanceScope.DistanceToNegativeSolution /
                (distanceScope.DistanceToPositiveSolution +
                 distanceScope.DistanceToNegativeSolution))).ToList();
    }
}