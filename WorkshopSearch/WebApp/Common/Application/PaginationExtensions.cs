namespace WebApp.Common.Application;

public static class PaginationExtensions
{
    public static int CalculateTotalPages(this int totalItems, int pageSize)
    {
        return (int) Math.Ceiling(totalItems / (double) pageSize);
    }
}