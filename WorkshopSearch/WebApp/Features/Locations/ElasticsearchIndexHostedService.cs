using WebApp.Elasticsearch;

namespace WebApp.Features.Locations;

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
        var indexInitializer = scope.ServiceProvider.GetRequiredService<ILocationIndexInitializer>();

        try
        {
            await indexInitializer.InitializeAsync();
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
