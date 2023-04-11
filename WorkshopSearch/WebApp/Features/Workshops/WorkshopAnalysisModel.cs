namespace WebApp.Features.Workshops;

public record WorkshopAnalysisModel(Guid Id, int MinAge, int MaxAge, decimal Price, int DaysCount, float Rating, 
    int ReviewsCount);