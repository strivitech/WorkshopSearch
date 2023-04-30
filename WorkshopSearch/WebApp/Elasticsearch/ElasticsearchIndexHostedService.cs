using WebApp.Features.Locations;
using WebApp.Features.Workshops;

namespace WebApp.Elasticsearch;

public class ElasticsearchIndexHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public ElasticsearchIndexHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var locationIndexInitializer = scope.ServiceProvider.GetRequiredService<ILocationIndexInitializer>();
        var workshopIndexInitializer = scope.ServiceProvider.GetRequiredService<IWorkshopIndexInitializer>();

        try
        {
            await locationIndexInitializer.InitializeAsync();
            await workshopIndexInitializer.InitializeAsync();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Failed to create Elasticsearch index during startup.", ex);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
