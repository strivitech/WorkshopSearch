using Microsoft.Extensions.Options;
using Nest;

namespace WebApp.Elasticsearch;

public class ElasticsearchService : IElasticsearchService
{
    private readonly ElasticClient _client;

    public ElasticsearchService(IOptions<ElasticsearchSettings> settings)
    {
        var uri = new Uri(settings.Value.Url);
        var connectionSettings = new ConnectionSettings(uri)
            .EnableApiVersioningHeader();
        _client = new ElasticClient(connectionSettings);
    }

    public ElasticClient GetClient()
    {
        return _client;
    }
}

