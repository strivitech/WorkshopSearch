using ErrorOr;

namespace WebApp.Features.Workshops;

public static partial class Errors
{
    public static class Workshops
    {
        public static Error DecisionMakingAnalysisOrderingFailed => Error.Failure(
            "Workshops.DecisionMakingAnalysisOrderingFailed",
            "Ordering workshop analysis models failed");

        public static Error GetByFilterFailure => Error.Failure("Workshops.GetByFilterFailure",
            "Getting workshops by filter failed");

        public static Error GetByDecisionMakingAnalysisFailure =>
            Error.Failure("Workshops.GetByDecisionMakingAnalysisFailure",
                "Getting workshops by decision making analysis failed"); 
    }
}