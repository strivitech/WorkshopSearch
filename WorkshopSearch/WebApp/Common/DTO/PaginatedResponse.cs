namespace WebApp.Common.DTO;

public record PaginatedResponse<T>(IList<T> Items, int PageNumber, int PageSize, int TotalPages);