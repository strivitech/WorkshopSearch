using WebApp.Common.Data;

namespace WebApp.Features.Workshops;

public record WorkshopConstrains(int MinAge, int MaxAge, decimal Price, DaysBitMask Days, int DaysCount);