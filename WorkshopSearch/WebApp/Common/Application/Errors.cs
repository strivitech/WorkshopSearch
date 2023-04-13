using ErrorOr;

namespace WebApp.Common.Application;

public static partial class Errors
{
    public static class DecisionMakingAnalysis
    {
        public static Error OrderAnalysisUnexpected => Error.Unexpected("DecisionMakingAnalysis.OrderAnalysisUnexpected",
            "Unexpected error while ordering analysis models");
    }
}