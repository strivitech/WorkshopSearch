using ErrorOr;

namespace WebApp.Features.Workshops;

public static partial class Errors
{
    public static class Workshops
    {
        public static Error GetByFilterFailure => Error.Failure("Workshops.GetByFilterFailure",
            "Getting workshops by filter failed");

        public static Error GetByDecisionMakingAnalysisFailure =>
            Error.Failure("Workshops.GetByDecisionMakingAnalysisFailure",
                "Getting workshops by decision making analysis failed");
        
        public static Error NotFound => Error.Failure("Workshops.NotFound", "Workshop not found");
    }
}