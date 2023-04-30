namespace WebApp.Features.Workshops;

public interface IWorkshopsTextSearcher
{
    Task<List<Guid>> FindIdsAsync(TextSearcherFilter filter);
}