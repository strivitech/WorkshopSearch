namespace WebApp.Common.Data;

public static class DaysBitMaskExtensions
{
    public static List<string> GetDaysFromBitMask(this DaysBitMask daysBitMask)
    {
        var days = Enum.GetValues(typeof(DaysBitMask))
            .Cast<DaysBitMask>()
            .Where(d => daysBitMask.HasFlag(d) && d != 0)
            .Select(d => d.ToString())
            .ToList();

        return days;
    }
}