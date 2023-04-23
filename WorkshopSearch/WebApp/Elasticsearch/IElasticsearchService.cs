using Nest;

namespace WebApp.Elasticsearch;

public interface IElasticsearchService
{
    ElasticClient GetClient();
}
