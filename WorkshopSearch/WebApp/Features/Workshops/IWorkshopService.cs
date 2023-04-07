namespace WebApp.Features.Workshops;

public interface IWorkshopService
{
    Task<IList<ShortWorkshopResponse>> GetByFilterAsync(WorkshopFilter filter);
}