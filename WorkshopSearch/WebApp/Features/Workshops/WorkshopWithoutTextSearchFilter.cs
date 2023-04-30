using WebApp.Common.Data;

namespace WebApp.Features.Workshops;

public record WorkshopWithoutTextSearchFilter(List<Guid>? Ids, int MinAge, int MaxAge, int MinPrice, int MaxPrice,
    List<DaysBitMask>? WorkingDays);
